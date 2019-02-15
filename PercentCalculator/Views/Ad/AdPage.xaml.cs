using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PercentCalculator.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PercentCalculator.Views.Ad
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdPage : ContentPage
	{
		public AdPage ()
		{
			InitializeComponent ();
		}

	    void InterstitialAdShowClick(object sender, EventArgs e)
	    {
	        DependencyService.Get<IAdInterstitial>().ShowAd();
	    }
    }
}