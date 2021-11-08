using System;
using System.Collections;
using MySql.Data.MySqlClient;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace ScanBarcodeSample.Droid
{
    [Activity(Label = "Plasscanner", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {


        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            ZXing.Net.Mobile.Forms.Android.Platform.Init();
            LoadApplication(new App());
            loaddata();
        }

        public async void loaddata()
        {
            MySqlConnection conn = new MySqlConnection("Server=sql11.freesqldatabase.com;Database=sql11449097;Uid=sql11449097;Pwd=J4JfDTfniP;");
            await conn.OpenAsync();

            MySqlCommand cmd = new MySqlCommand("SELECT productnaam, prijs, ingredienten, perceplastic, bedrijf FROM plasticscanner WHERE Barcode = " + MainPage.sendtext(), conn);
            cmd.Connection = conn;

            MySqlDataReader rdr = cmd.ExecuteReader();
            if (MainPage.senddata() == "EAN_13" || MainPage.senddata() == "EAN_8")
            {
                MainPage.scanResultText.Text = rdr.ToString();
            }
            else
            {
                MainPage.scanResultText.Text = MainPage.sendtext() + " (type: " + MainPage.senddata() + ")";
            }




        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}