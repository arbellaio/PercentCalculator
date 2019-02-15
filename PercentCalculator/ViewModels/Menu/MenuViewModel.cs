using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using PercentCalculator.Helpers;
using PercentCalculator.Views.SubViews;
using Xamarin.Forms;

namespace PercentCalculator.ViewModels.Menu
{
    public class  MenuViewModel : BaseViewModel
    {
        public Color _textColor = SettingsHelper.GetGlobalTextColor();
        public Color TextColor
        {
            get => _textColor;
            set { _textColor = value; OnPropertyChanged(nameof(TextColor)); }
        }
        public ICommand PercentageCommand { get; set; }
        public ICommand MarginCommand { get; set; }
        public ICommand TipCommand { get; set; }
        public ICommand PercentageChangeCommand { get; set; }
        public ICommand PercentageOfCommand { get; set; }
        public ICommand PercentageDiscountCommand { get; set; }
        public ICommand PercentageIncreaseCommand { get; set; }
        public ICommand MarkUpCommand { get; set; }
        public ICommand SalesTaxCommand { get; set; }
        public ICommand FractionToPercentageCommand { get; set; }
        public ICommand CompoundInterestCommand { get; set; }
        public ICommand VatCommand { get; set; }
        public ICommand InflationCommand { get; set; }
        public ICommand CumulationGrowthCommand { get; set; }
        public ICommand MarginVatCommand { get; set; }
        public ICommand DoublingCommand { get; set; }
        public ICommand MarginSalesTaxCommand { get; set; }

        public  MenuViewModel()
        {
            PercentageCommand = new Command(OpenPercentageCommand);
            MarginCommand = new Command(OpenMarginCommand);
            TipCommand = new Command(OpenTipCommand);
            PercentageChangeCommand = new Command(OpenPercentageChangeCommand);
            PercentageOfCommand = new Command(OpenPercentageOfCommand);
            PercentageDiscountCommand = new Command(OpenPercentageDiscountCommand);
            PercentageIncreaseCommand = new Command(OpenPercentageIncreaseCommand);
            MarkUpCommand = new Command(OpenMarkUpCommand);
            SalesTaxCommand = new Command(OpenSalesTaxCommand);
            FractionToPercentageCommand = new Command(OpenFractionToPercentageCommand);
            CompoundInterestCommand = new Command(OpenCompoundInterestCommand);
            VatCommand = new Command(OpenVatCommand);
            InflationCommand = new Command(OpenInflationCommand);
            CumulationGrowthCommand = new Command(OpenCumulativeGrowthCommand);
            MarginVatCommand = new Command(OpenMarginVatCommand);
            DoublingCommand = new Command(OpenDoublingCommand);
            MarginSalesTaxCommand = new Command(OpenMarginSalesTaxCommand);
        }

        private void OpenDoublingCommand()
        {
            App.Current.MainPage.Navigation.PushAsync(new DoublingCalculator());

        }

        private void OpenMarginVatCommand()
        {
            App.Current.MainPage.Navigation.PushAsync(new MarginVat());
        }

        private void OpenMarginSalesTaxCommand()
        {
            App.Current.MainPage.Navigation.PushAsync(new MarginSalesTax());
        }

        private void OpenCumulativeGrowthCommand()
        {
            App.Current.MainPage.Navigation.PushAsync(new CumulativeGrowthCalculator());
        }

        private void OpenInflationCommand()
        {
            App.Current.MainPage.Navigation.PushAsync(new InflationCalculator());
        }

        private async void OpenVatCommand()
        {
            await App.Current.MainPage.Navigation.PushAsync(new VatTaxCalculator());
        }

        private async void OpenCompoundInterestCommand()
        {
            await App.Current.MainPage.Navigation.PushAsync(new CompoundInterestCalculator());
        }

        private async void OpenFractionToPercentageCommand()
        {
            await App.Current.MainPage.Navigation.PushAsync(new FractionToPercentageCalculator());
        }

        private async void OpenSalesTaxCommand()
        {
            await App.Current.MainPage.Navigation.PushAsync(new SalesTaxCalculator());
        }

        private async void OpenMarkUpCommand()
        {
            await App.Current.MainPage.Navigation.PushAsync(new MarkUpCalculator());
        }

        private async void OpenPercentageIncreaseCommand()
        {
            await App.Current.MainPage.Navigation.PushAsync(new PercentageIncrease());
        }

        private async void OpenPercentageDiscountCommand()
        {
            await App.Current.MainPage.Navigation.PushAsync(new PercentageDiscount());
        }

        private async void OpenPercentageOfCommand()
        {
            await App.Current.MainPage.Navigation.PushAsync(new PercentageOf());
        }

        private async void OpenPercentageChangeCommand()
        {
            await App.Current.MainPage.Navigation.PushAsync(new PercentageChange());
        }

        private async void OpenTipCommand()
        {
            await App.Current.MainPage.Navigation.PushAsync(new TipCalculator());
        }

        private async void OpenMarginCommand()
        {
            await App.Current.MainPage.Navigation.PushAsync(new MarginCalculator());
        }

        private async void OpenPercentageCommand()
        {
            await App.Current.MainPage.Navigation.PushAsync(new PercentageCalculator());
        }
    }
}
