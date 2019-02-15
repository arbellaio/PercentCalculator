using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PercentCalculator.Constants;
using PercentCalculator.Helpers;
using PercentCalculator.ViewModels.Settings;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PercentCalculator.Views.Settings.SettingsPopUpColorPalette
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingNavColor : PopupPage
    {
        public SettingsViewModel viewModel => BindingContext as SettingsViewModel;

        public SettingNavColor()
        {
            InitializeComponent();
        }

       
        private async void SelectedColor(object sender, EventArgs e)
        {
            var button = (Button) sender;
            var buttonColor = button.BackgroundColor;

            await Navigation.PopPopupAsync();
            viewModel.NavigationBarColor = buttonColor;
            viewModel.NavColorSelectionBg = buttonColor;
        }
    }
}