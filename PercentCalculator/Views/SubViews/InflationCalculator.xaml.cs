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
	public partial class InflationCalculator : ContentPage
	{
		public InflationCalculator ()
		{
			InitializeComponent ();
		    CurrencySymbol.Text = SettingsHelper.GetGlobalCurrencySymbol();
		    CurrencySymbol2.Text = SettingsHelper.GetGlobalCurrencySymbol();
		    CurrencySymbol3.Text = SettingsHelper.GetGlobalCurrencySymbol();

		}

	    private async void GoBack(object sender, EventArgs e)
	    {
	        await Navigation.PopAsync();
	    }

	    private void CalculateFractionToPercentageValue(object sender, EventArgs e)
	    {
	        if (!string.IsNullOrEmpty(Value1.Text) && !string.IsNullOrEmpty(Value2.Text) && !string.IsNullOrEmpty(Value3.Text) && !string.IsNullOrEmpty(Value4.Text))
	        {
	            var value1 = Convert.ToDecimal(Value1.Text);
	            var value2 = Convert.ToDecimal(Value2.Text);
	            var value3 = Convert.ToDecimal(Value3.Text);
	            var value4 = Convert.ToDecimal(Value4.Text);
	            var result = FormulasHelper.Formula14(value1, value2,value3,value4);
	            var resultformat = DecimalHelper.FormatString(result.Item1);
	            var resultformat2 = DecimalHelper.FormatString(result.Item2);
	            var resultformat3 = DecimalHelper.FormatString(value1); 

                Result.Text = resultformat.ToString(CultureInfo.CurrentCulture);
	            Result1.Text = resultformat2.ToString(CultureInfo.CurrentCulture);
	            Result2.Text = resultformat3;
	        }
	        else
	        {
	            DependencyService.Get<IMessage>().ShortAlert("Please Enter Values To Calculate");
	        }
	    }
    }
}