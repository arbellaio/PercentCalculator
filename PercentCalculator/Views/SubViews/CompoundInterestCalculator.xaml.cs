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
    public partial class CompoundInterestCalculator : ContentPage
    {
        public CompoundInterestCalculator()
        {
            InitializeComponent();
            CurrencySymbol.Text = SettingsHelper.GetGlobalCurrencySymbol();
            CurrencyLabel2.Text = SettingsHelper.GetGlobalCurrencySymbol();
        }

        private async void GoBack(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void CalculateFractionToPercentageValue(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Value1.Text) && !string.IsNullOrEmpty(Value2.Text) && !string.IsNullOrEmpty(Value3.Text))
            {
                double compoundedValue = 1;
                switch (Value4.SelectedIndex)
                {
                    case 0:
                        compoundedValue = 1;
                        break;
                    case 1:
                        compoundedValue = 2;
                        break;
                    case 2:
                        compoundedValue = 4;
                        break;
                    case 3:
                        compoundedValue = 12;
                        break;
                    case 4:
                        compoundedValue = 364;
                        break;
                }
                var value1 = Convert.ToDecimal(Value1.Text);
                var value2 = Convert.ToDouble(Value2.Text);
                var value3 = Convert.ToDouble(Value3.Text);
                var value4 = Convert.ToDouble(compoundedValue);
                var result = FormulasHelper.Formula11(value1, value2,value3,value4);
                var resultformat = DecimalHelper.FormatString(result);
                Result.Text = resultformat.ToString(CultureInfo.CurrentCulture);
            }
            else
            {
                DependencyService.Get<IMessage>().ShortAlert("Please Enter Both Values To Calculate");
            }
        }
    }
}