using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using XamarinSqLiteApp;
using System.IO;

namespace XamarinSqLiteApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button inbtn;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);            
            SetContentView(Resource.Layout.activity_main);
            CreateDatabase();
            inbtn = FindViewById<Button>(Resource.Id.button1);
            inbtn.Click += İnbtn_Click;
            
        }

        private void İnbtn_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(Insert));
        }

        public string CreateDatabase()
        {
            var output = "";
            output += "Creating database if it doesn't exists";
            string dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),"users.db3");
            output += " Database is created....";
            return output;
        }
    }
}