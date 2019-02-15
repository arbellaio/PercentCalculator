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
	public partial class PercentageChange : ContentPage
	{
		public PercentageChange ()
		{
			InitializeComponent ();
		    CurrencySymbol2.Text = SettingsHelper.GetGlobalCurrencySymbol();
		    CurrencySymbol1.Text = SettingsHelper.GetGlobalCurrencySymbol();
		}

	    private void GoBack(object sender, EventArgs e)
	    {
	        Navigation.PopAsync();
	    }

	    private void CalculatePercentageChange(object sender, EventArgs e)
	    {
	        if (!string.IsNullOrEmpty(Value1.Text) && !string.IsNullOrEmpty(Value2.Text))
	        {
	            var value1 = Convert.ToDecimal(Value1.Text);
	            var value2 = Convert.ToDecimal(Value2.Text);
	            var result = FormulasHelper.Formula5(value1, value2);
	            var resultformat = DecimalHelper.FormatString(result);
                Result.Text = resultformat.ToString(CultureInfo.CurrentCulture) + SettingsHelper.GetGlobalCurrencySymbol();
            }
	        else
	        {
	            DependencyService.Get<IMessage>().ShortAlert("Please Enter Both Values To Calculate");
	        }
        }
	}
}