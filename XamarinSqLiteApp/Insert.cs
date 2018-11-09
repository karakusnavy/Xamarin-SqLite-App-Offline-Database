using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using SQLitePCL;

namespace XamarinSqLiteApp
{
    [Activity(Label = "Insert")]
    public class Insert : Activity
    {
        Button save, select;
        EditText name, nickname, dept, place;
        TextView info;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Insert);
            name = FindViewById<EditText>(Resource.Id.editText1);
            nickname = FindViewById<EditText>(Resource.Id.editText2);
            dept = FindViewById<EditText>(Resource.Id.editText3);
            select = FindViewById<Button>(Resource.Id.goster);
            select.Click += Select_Click;
            place = FindViewById<EditText>(Resource.Id.editText4);
            info = FindViewById<TextView>(Resource.Id.textView6);
            save = FindViewById<Button>(Resource.Id.button1);
            save.Click += Save_Click;
        }

        private void Select_Click(object sender, EventArgs e)
        {
            string dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "users.db3");
            var db = new SQLiteConnection(dbpath);
            var data = db.Table<databse>();
            var datas = (from values in data
                         select new databse
                         {
                             name = values.name,
                             nickname = values.nickname,
                             dept = values.dept,
                             place = values.place

                         }).ToList<databse>();
            if (datas.Count>=1)
            {
                foreach (var val in datas)
                {
                    info.Text = val.name;
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            databse dget = new databse();
            try
            {
                string dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "users.db3");
                var db = new SQLiteConnection(dbpath);
                db.CreateTable<databse>();
                dget.name = name.Text;
                dget.nickname = nickname.Text;
                dget.dept = dept.Text;
                dget.place = place.Text;
                db.Insert(dget);
            }
            catch (Exception)
            {
                
                
            }
        }
    }
}