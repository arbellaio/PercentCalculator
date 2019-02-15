using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PercentCalculator.Colors;
using PercentCalculator.Constants;
using PercentCalculator.Helpers;
using PercentCalculator.Providers;
using PercentCalculator.Resources.Language;
using PercentCalculator.ViewModels.Settings;
using PercentCalculator.Views.Menu;
using PercentCalculator.Views.Settings.SettingsLanguagePop;
using PercentCalculator.Views.Settings.SettingsPopUpColorPalette;
using Plugin.InAppBilling;
using Plugin.InAppBilling.Abstractions;
using Plugin.Multilingual;
using Rg.Plugins.Popup.Extensions;
using TeixeiraSoftware.Finance;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PercentCalculator.Views.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsViewModel viewModel => BindingContext as SettingsViewModel;
        readonly List<string> _listCurrencies = new List<string>();

        public SettingsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            formatpicker.Items.Add("1 500 000.5");
            formatpicker.Items.Add("1,500,000.5");
            formatpicker.Items.Add("1500000.5");
            formatpicker.Items.Add("1 500 000,5");
            formatpicker.Items.Add("1.500.000,5");
            formatpicker.Items.Add("1500000,5");

            formatpicker.SelectedIndex = SettingsHelper.GetGlobalFormat();


            picker.Items.Add("English");
            picker.Items.Add("German");
            picker.Items.Add("Dutch");
            picker.Items.Add("Hindi");
            picker.Items.Add("French");
            picker.SelectedItem = SettingsHelper.GetGlobalLanguage();

            viewModel.BackgroundColor = SettingsHelper.GetGlobalBackGroundColor();
            viewModel.NavigationBarColor = SettingsHelper.GetGlobalNavigationBarColor();
            viewModel.CurrencySymbol = SettingsHelper.GetGlobalCurrencySymbol();

            if (!SettingsHelper.GetGlobalBackGroundColor().Equals(SettingsHelper.DarkModeBackgroundColor()) &&
                !SettingsHelper.GetGlobalNavigationBarColor().Equals(SettingsHelper.DarkModeNavigationBarColor()))
            {
                Application.Current.Properties[Keys.DarkMode] = false;
            }

            if (Application.Current.Properties.ContainsKey(Keys.DarkMode))
            {
                var checkMode = (bool) Application.Current.Properties[Keys.DarkMode];
                ModeToggle.IsToggled = checkMode;
            }

            if (Application.Current.Properties.ContainsKey(Keys.CurrencySymbol))
            {
                CurrencySymbol.Text = Application.Current.Properties[Keys.CurrencySymbol].ToString();
            }

            //SelectedLanguageLabel.Text = SettingsHelper.GetGlobalLanguage();
            await Task.Run(() =>
            {
                foreach (var currency in Currency.AllCurrencies.ToList())
                {
                    _listCurrencies.Add(currency.AlphabeticCode);
                }
            });
            CurrencyPicker.ItemsSource = _listCurrencies;
        }

        private void DarkModeOn(object sender, ToggledEventArgs e)
        {
            viewModel.DarkModeOn(e.Value);
        }

        void Handle_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var selectedLanguageString = picker.SelectedItem.ToString();
            var selectedLanguage = CrossMultilingual.Current.NeutralCultureInfoList.ToList()
                .First(element => element.EnglishName.Contains(selectedLanguageString));
            if (selectedLanguage != null)
            {
                CrossMultilingual.Current.CurrentCultureInfo = selectedLanguage;
                AppResources.Culture = CrossMultilingual.Current.CurrentCultureInfo;
                Application.Current.Properties[Keys.Language] =
                    CrossMultilingual.Current.CurrentCultureInfo.EnglishName;
            }
        }

        private void SaveChanges(object sender, EventArgs e)
        {
            viewModel.SetBackgroundAndNavBarColor();
            var color = ExtensionMethods.GetRgb(SettingsHelper.GetGlobalNavigationBarColor());
            DependencyService.Get<IStatusBarColorHandler>().StatusBarColor(color.Item1, color.Item2, color.Item3);


            Application.Current.MainPage = new NavigationPage(new MenuPage())
            {
                BarBackgroundColor = SettingsHelper.GetGlobalNavigationBarColor(),
                BackgroundColor = SettingsHelper.GetGlobalBackGroundColor(),
            };
        }

        private async void OpenNavBarPopup(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new SettingNavColor());
        }

        private void GoBack(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }


        private async void LanguagePicker_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new LanguagePopUpPage());
        }

        private void FormatPicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (formatpicker != null)
            {
                Application.Current.Properties[Keys.Format] = formatpicker.SelectedIndex;
            }
        }

        private async void RemoveAds(object sender, EventArgs e)
        {
            try
            {
                var productId = "removeads";

                var connected = await CrossInAppBilling.Current.ConnectAsync();

                if (!connected)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Not Connected to Internet", "Ok");
                    return;
                }

                //try to purchase item
                var purchase = await CrossInAppBilling.Current.PurchaseAsync(productId, ItemType.InAppPurchase, "apppayload");
                if (purchase == null)
                {
                    await App.Current.MainPage.DisplayAlert("Warning", "Item not purchased", "Ok");
                }
                else
                {
                    //Purchased, save this information
                    var id = purchase.Id;
                    var token = purchase.PurchaseToken;
                    var state = purchase.State;

                    var iApObj = new IapModel
                    {
                        Id = id,
                        Token = token,
                        State = state.ToString()
                    };
                    Application.Current.Properties[Keys.IapInfo] = JsonConvert.SerializeObject(iApObj);
                }
            }
            catch (Exception ex)
            {
                //Something bad has occurred, alert user
            }
            finally
            {
                //Disconnect, it is okay if we never connected
                await CrossInAppBilling.Current.DisconnectAsync();
            }
        }
    }
}