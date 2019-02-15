using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Ads;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PercentCalculator.CustomRenderer;
using PercentCalculator.Droid.Renderer.AdMobRenderer;
using Xamarin.Forms;

[assembly: Dependency(typeof(AdInterstitial_Droid))]
namespace PercentCalculator.Droid.Renderer.AdMobRenderer
{
    public class AdInterstitial_Droid : IAdInterstitial
    {
        InterstitialAd interstitialAd;

        public AdInterstitial_Droid()
        {
            interstitialAd = new InterstitialAd(Android.App.Application.Context);

            // TODO: change this id to your admob id  
            interstitialAd.AdUnitId = "ca-app-pub-8240459894349209/3623832274";
            LoadAd();
        }

        void LoadAd()
        {
            var requestbuilder = new AdRequest.Builder();
            interstitialAd.LoadAd(requestbuilder.Build());
            requestbuilder.AddTestDevice("2AD7A2CAA59C1F2447BAE68CA85C550B");
        }

        public void ShowAd()
        {
            if (interstitialAd.IsLoaded)
                interstitialAd.Show();

            LoadAd();
        }
    }
}