using System;
using System.Collections.Generic;
using System.Text;
using PercentCalculator.Colors;
using PercentCalculator.Constants;
using PercentCalculator.Helpers;
using PercentCalculator.Views.Settings.SettingsPopUpColorPalette;
using TeixeiraSoftware.Finance;
using Xamarin.Forms;

namespace PercentCalculator.ViewModels.Settings
{
    public class SettingsViewModel : BaseViewModel
    {

        public Color _navigationBarColor = SettingsHelper.GetGlobalNavigationBarColor();
        public Color NavigationBarColor
        {
            get => _navigationBarColor;
            set { _navigationBarColor = value; OnPropertyChanged(nameof(NavigationBarColor)); }
        }

        public Color _backgroundColor = SettingsHelper.GetGlobalBackGroundColor();
        public Color BackgroundColor
        {
            get => _backgroundColor;
            set { _backgroundColor = value; OnPropertyChanged(nameof(BackgroundColor)); }
        }

        public Color _navColorSelectionButtonBg = Color.PaleVioletRed;
        public Color NavColorSelectionBg
        {
            get => _navColorSelectionButtonBg;
            set
            {
                _navColorSelectionButtonBg = value;
                OnPropertyChanged(nameof(NavColorSelectionBg));
            }
        }


        public string _selectedCurrency;
        public string SelectedCurrency
        {
            get => _selectedCurrency;
            set
            {
                _selectedCurrency = value;
                SetCurrencySymbol();
                OnPropertyChanged();
            }
        }

        public string _currencySymbol = "$";
        public string CurrencySymbol
        {
            get => _currencySymbol;
            set
            {
                _currencySymbol = value;
                OnPropertyChanged(() => this.CurrencySymbol);
            }
        }


        public string SetCurrencySymbol()
        {
            var symbol = CurrencySymbolHelper.GetCurrencySymbol(SelectedCurrency);
            CurrencySymbol = symbol;
            Application.Current.Properties[Keys.CurrencySymbol] = symbol;
            return symbol;
        }

      

        public bool DarkModeOn(bool mode)
        {
            if (mode)
            {
                Application.Current.Properties[Keys.DarkMode] = true;
                BackgroundColor = SettingsHelper.DarkModeBackgroundColor();
                NavigationBarColor = SettingsHelper.DarkModeNavigationBarColor();
                Application.Current.Properties[Keys.TextColor] = AppColors.TextColorWhite; 
                return true;
            }
                Application.Current.Properties[Keys.DarkMode] = false;
                BackgroundColor = SettingsHelper.NormalBackgroundColor();
                NavigationBarColor = SettingsHelper.NormalNavigationColor();
                Application.Current.Properties[Keys.TextColor] = AppColors.TextColorBlack;

            return false;
        }

        public async void SetBackgroundAndNavBarColor()
        {
            Application.Current.Properties[Keys.BackgroundColor] = ExtensionMethods.GetHexString(BackgroundColor);
            Application.Current.Properties[Keys.NavigationBarColor] = ExtensionMethods.GetHexString(NavigationBarColor);
            await Application.Current.SavePropertiesAsync();
        }

    }
}
