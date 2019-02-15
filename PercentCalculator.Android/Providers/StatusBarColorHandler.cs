using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PercentCalculator.Droid.Providers;
using PercentCalculator.Providers;
using Plugin.CurrentActivity;
using Xamarin.Forms;
using Color = Android.Graphics.Color;

[assembly: Xamarin.Forms.Dependency(typeof(StatusBarColorHandler))]
namespace PercentCalculator.Droid.Providers
{
    public class StatusBarColorHandler : IStatusBarColorHandler
    {
        public void StatusBarColor(int r, int g, int b)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var currentWindow = GetCurrentWindow();
                    currentWindow.DecorView.SystemUiVisibility = 0;
                    currentWindow.SetStatusBarColor(Color.Rgb(r,g,b));
                });
            }
        }

        Window GetCurrentWindow()
        {
            var window = CrossCurrentActivity.Current.Activity.Window;

            // clear FLAG_TRANSLUCENT_STATUS flag:
            window.ClearFlags(WindowManagerFlags.TranslucentStatus);

            // add FLAG_DRAWS_SYSTEM_BAR_BACKGROUNDS flag to the window
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

            return window;
        }
    }
}