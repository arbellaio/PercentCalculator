﻿using System;
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
	public partial class VatTaxCalculator : ContentPage
	{
		public VatTaxCalculator ()
		{
			InitializeComponent ();
		    CurrencySymbol.Text = SettingsHelper.GetGlobalCurrencySymbol();
		}

	    private async void GoBack(object sender, EventArgs e)
	    {
	        await Navigation.PopAsync();
	    }

	    private void CalculateFractionToPercentageValue(object sender, EventArgs e)
	    {
	        if (!string.IsNullOrEmpty(Value1.Text) && !string.IsNullOrEmpty(Value2.Text))
	        {
	            var value1 = Convert.ToDecimal(Value1.Text);
	            var value2 = Convert.ToDecimal(Value2.Text);
	            var result = FormulasHelper.Formula12(value1, value2);
	            var resultformat = DecimalHelper.FormatString(result.Item1);
	            var resultformat2 = DecimalHelper.FormatString(result.Item2);

                Result.Text = resultformat.ToString(CultureInfo.CurrentCulture);
	            Result1.Text = resultformat2.ToString(CultureInfo.CurrentCulture);
	        }
	        else
	        {
	            DependencyService.Get<IMessage>().ShortAlert("Please Enter Values To Calculate");
	        }
	    }
    }
}