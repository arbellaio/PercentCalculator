using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Ads;
using Android.Gms.Ads.Mediation;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using PercentCalculator.CustomRenderer;
using PercentCalculator.Droid.Renderer.AdMobRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;


[assembly: ExportRenderer(typeof(AdBanner), typeof(AdBanner_Droid))]
namespace PercentCalculator.Droid.Renderer.AdMobRenderer
{
    public class AdBanner_Droid : ViewRenderer
    {
        Context context;
        public AdBanner_Droid(Context _context) : base(_context)
        {
            context = _context;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> elementChangedEventArgs)
        {
            base.OnElementChanged(elementChangedEventArgs);
            if (elementChangedEventArgs.OldElement == null)
            {
                var adView = new AdView(context);
//                var adParams = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);
//                adView.LayoutParameters = adParams;

                switch ((Element as AdBanner).Size)
                {
                    case AdBanner.Sizes.Standardbanner:
                        adView.AdSize = AdSize.Banner;
                        break;
                    case AdBanner.Sizes.LargeBanner:
                        adView.AdSize = AdSize.LargeBanner;
                        break;
                    case AdBanner.Sizes.MediumRectangle:
                        adView.AdSize = AdSize.MediumRectangle;
                        break;
                    case AdBanner.Sizes.FullBanner:
                        adView.AdSize = AdSize.FullBanner;
                        break;
                    case AdBanner.Sizes.Leaderboard:
                        adView.AdSize = AdSize.Leaderboard;
                        break;
                    case AdBanner.Sizes.SmartBannerPortrait:
                        adView.AdSize = AdSize.SmartBanner;
                        break;
                    default:
                        adView.AdSize = AdSize.Banner;
                        break;
                }
                // TODO: change this id to your admob id  
//                adView.AdUnitId = "ca-app-pub-8240459894349209/6006453035";
//                adView.AdUnitId = "ca-app-pub-3940256099942544/6300978111";
                adView.AdUnitId = "ca-app-pub-2461742552301569/7967912131";
                var requestbuilder = new AdRequest.Builder();
//                requestbuilder.AddTestDevice("2AD7A2CAA59C1F2447BAE68CA85C550B");
//                requestbuilder.AddTestDevice("C6BFD902878C2AFFB9D2F66066248141");
                
//                requestbuilder.AddTestDevice("356926091475745");
                adView.LoadAd(requestbuilder.Build());
                SetNativeControl(adView);
            }
        }
    }
}