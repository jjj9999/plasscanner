using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace ScanBarcodeSample
{
    
    public partial class MainPage : ContentPage
    {
         static string data;
         static string text;
        public MainPage()
        {
            InitializeComponent();
        }


        public void ZXingScannerView_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                text = result.Text;
                data = result.BarcodeFormat.ToString();
            });
        }

        public static string senddata()
        {
            return data;
        }
        public static string sendtext()
        {
            return text;
        }

        void SwipeItem_Invoked(System.Object sender, System.EventArgs e)
        {
            Device.OpenUri(new Uri("https://i483537.hera.fhict.nl/"));

        }
    }
}
