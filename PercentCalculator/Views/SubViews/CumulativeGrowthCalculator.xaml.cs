using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PercentCalculator.Helpers;
using PercentCalculator.Providers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PercentCalculator.Views.SubViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CumulativeGrowthCalculator : ContentPage
	{
		public CumulativeGrowthCalculator ()
		{
			InitializeComponent ();
		    CurrencySymbol.Text = SettingsHelper.GetGlobalCurrencySymbol();
		    CurrencySymbol2.Text = SettingsHelper.GetGlobalCurrencySymbol();
		    CurrencySymbol4.Text = SettingsHelper.GetGlobalCurrencySymbol();
		}


	    private async void GoBack(object sender, EventArgs e)
	    {
	        await Navigation.PopAsync();
	    }

	    private void CalculateCumulativeGrowthPercentage(object sender, EventArgs e)
	    {
	        if (!string.IsNullOrEmpty(Value1.Text) && !string.IsNullOrEmpty(Value2.Text) && !string.IsNullOrEmpty(Value3.Text))
	        {
	            var value1 = Convert.ToDouble(Value1.Text);
	            var value2 = Convert.ToDouble(Value2.Text);
	            var value3 = Convert.ToDouble(Value3.Text);
	            var result = FormulasHelper.Formula15(value1, value2,value3);
	            var resultformat1 = DecimalHelper.FormatString(result.Item1);
	            var resultformat2 = DecimalHelper.FormatString(result.Item2);
	            var resultformat3 = DecimalHelper.FormatString(result.Item3);
                Result.Text = resultformat1.ToString(CultureInfo.CurrentCulture);
	            Result2.Text = resultformat2.ToString(CultureInfo.CurrentCulture); 
	            Result3.Text = resultformat3.ToString(CultureInfo.CurrentCulture); 
	        }
	        else
	        {
	            DependencyService.Get<IMessage>().ShortAlert("Please Enter Values To Calculate");
	        }
	    }
    }
}