using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PercentCalculator.Helpers;
using PercentCalculator.Providers;
using PercentCalculator.Resources.Language;
using PercentCalculator.ViewModels.Menu;
using PercentCalculator.Views.History;
using PercentCalculator.Views.Settings;
using PercentCalculator.Views.SubViews;
using Rg.Plugins.Popup.Extensions;
using TouchEffect;
using TouchEffect.EventArgs;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PercentCalculator.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public MenuViewModel viewModel => BindingContext as MenuViewModel;
        public MenuPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Task.Run(() =>
            {
                var color = SettingsHelper.GetGlobalNavigationBarColor().GetRgb();
                DependencyService.Get<IStatusBarColorHandler>().StatusBarColor(color.Item1, color.Item2, color.Item3);
                PcDescription.Text = "20% " + AppResources.off + " " + SettingsHelper.GetGlobalCurrencySymbol() + "50 = " + SettingsHelper.GetGlobalCurrencySymbol() + "10";
                PiDescription.Text = AppResources.Increase + " " + SettingsHelper.GetGlobalCurrencySymbol() + "50 " + AppResources.By + " 20% = " + SettingsHelper.GetGlobalCurrencySymbol() + "60";
                PdDescription.Text = SettingsHelper.GetGlobalCurrencySymbol() + "50 " + AppResources.With + " 20% " + AppResources.Discoun + " = " + SettingsHelper.GetGlobalCurrencySymbol() + "40";
                PoDescription.Text = SettingsHelper.GetGlobalCurrencySymbol() + "20 " + AppResources.PoDescription1 + " " + SettingsHelper.GetGlobalCurrencySymbol() + " 50 = 40%";
                PchDescription.Text = AppResources.PchDescription1 + " " + SettingsHelper.GetGlobalCurrencySymbol() + "20 " + AppResources.PchDescription2 + " " + SettingsHelper.GetGlobalCurrencySymbol() + "50 = 150%";
                TcDescription.Text = AppResources.TcDescription;
                MgDescription.Text = AppResources.MgDescription;
                MkDescription.Text = AppResources.MkDescription;
                StDescription.Text = AppResources.StDescription;
                fractionPercentage.Text = AppResources.fractionPercentage;
                compoundInterest.Text = AppResources.compoundInterest2;
                vat.Text = AppResources.vat1;
                doubling.Text = AppResources.doubling;
                inflation.Text = AppResources.inflation1;
                cumulative.Text = AppResources.cumulative;
                msDescription.Text = AppResources.MsDescription;
                mvDescription.Text = AppResources.MvDescription;
                BackgroundColor = SettingsHelper.GetGlobalBackGroundColor();
            });
            
        }

        private async void SettingsPage(object sender, EventArgs e)
        {
            var settingsPage = new SettingsPage();
            await Navigation.PushAsync(settingsPage);
        }

    }
}