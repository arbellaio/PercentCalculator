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
	public partial class DoublingCalculator : ContentPage
	{
		public DoublingCalculator ()
		{
			InitializeComponent ();
		}

	    private async void GoBack(object sender, EventArgs e)
	    {
	        await Navigation.PopAsync();
	    }

	    private void CalculateFractionToPercentageValue(object sender, EventArgs e)
	    {
	        if (!string.IsNullOrEmpty(Value1.Text))
	        {
	            var value1 = Convert.ToDecimal(Value1.Text);
	            var result = FormulasHelper.Formula13(value1);
	            var resultformat = DecimalHelper.FormatString(result);
                Result.Text = resultformat.ToString(CultureInfo.CurrentCulture);
	        }
	        else
	        {
	            DependencyService.Get<IMessage>().ShortAlert("Please Enter Values To Calculate");
	        }
	    }
    }
}