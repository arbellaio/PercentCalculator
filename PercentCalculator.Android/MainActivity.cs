using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Gms.Ads;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using PercentCalculator.Droid.Providers;
using Plugin.CurrentActivity;
using Plugin.InAppBilling;
using Xamarin.Forms;

namespace PercentCalculator.Droid
{
    [Activity(Label = "PercentCalculator", Icon = "@drawable/aicon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            MobileAds.Initialize(ApplicationContext, "ca-app-pub-2461742552301569~4220238810");
//            MobileAds.Initialize(ApplicationContext, "ca-app-pub-8240459894349209~2095128181");
            CrossCurrentActivity.Current.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            InAppBillingImplementation.HandleActivityResult(requestCode, resultCode, data);
        }
    }
}