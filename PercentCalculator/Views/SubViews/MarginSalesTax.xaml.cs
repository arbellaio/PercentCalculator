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
	public partial class MarginSalesTax : ContentPage
	{
		public MarginSalesTax ()
		{
			InitializeComponent();
		}

	    private void GoBack(object sender, EventArgs e)
	    {
	        Navigation.PopAsync();
	    }

	    private void CalculateMargin(object sender, EventArgs e)
	    {
	        if (!string.IsNullOrEmpty(Value1.Text) && !string.IsNullOrEmpty(Value2.Text) && !string.IsNullOrEmpty(Value3.Text))
	        {
	            var cost = Convert.ToDecimal(Value1.Text);
	            var marginPercentage = Convert.ToDecimal(Value2.Text);
	            var saleTaxPercentage = Convert.ToDecimal(Value3.Text);
	            var result = FormulasHelper.Formula18(cost, marginPercentage, saleTaxPercentage);
	            var netPrice = DecimalHelper.FormatString(result.Item1);
	            var grossPrice = DecimalHelper.FormatString(result.Item2);
	            var profit = DecimalHelper.FormatString(result.Item3);

	            Result.Text = netPrice.ToString(CultureInfo.CurrentCulture) + SettingsHelper.GetGlobalCurrencySymbol();
	            Result2.Text = grossPrice.ToString(CultureInfo.CurrentCulture) + SettingsHelper.GetGlobalCurrencySymbol();
	            Result3.Text = profit.ToString(CultureInfo.CurrentCulture) + SettingsHelper.GetGlobalCurrencySymbol();
	        }
	        else
	        {
	            DependencyService.Get<IMessage>().ShortAlert("Please Enter Both Values To Calculate");
	        }
	    }
    }
}