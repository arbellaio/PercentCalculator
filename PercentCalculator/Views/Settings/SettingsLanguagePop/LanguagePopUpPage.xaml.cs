using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PercentCalculator.Constants;
using PercentCalculator.Helpers;
using PercentCalculator.Resources.Language;
using PercentCalculator.Views.Menu;
using Plugin.Multilingual;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PercentCalculator.Views.Settings.SettingsLanguagePop
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LanguagePopUpPage : PopupPage
	{
		public LanguagePopUpPage ()
		{
			InitializeComponent();
		    picker.Items.Add("English");
		    picker.Items.Add("German");
		    picker.Items.Add("Dutch");
		    picker.Items.Add("Hindi");
		    picker.Items.Add("French");
		    picker.SelectedItem = SettingsHelper.GetGlobalLanguage();
        }

	    void OnUpdateLangugeClicked(object sender, System.EventArgs e)
	    {
	        try
	        {
	            if (picker.SelectedIndex == -1)
	            {
	                Application.Current.MainPage.DisplayAlert("Language Not Selected", "Please Select Language", "Ok");
	            }
	            else
	            {
	                var selectedLanguageString = picker.SelectedItem.ToString();
	                var selectedLanguage = CrossMultilingual.Current.NeutralCultureInfoList.ToList().First(element => element.EnglishName.Contains(selectedLanguageString));
	                if (selectedLanguage != null)
	                {
	                    CrossMultilingual.Current.CurrentCultureInfo = selectedLanguage;
	                    AppResources.Culture = CrossMultilingual.Current.CurrentCultureInfo;
	                    Application.Current.Properties[Keys.Language] = CrossMultilingual.Current.CurrentCultureInfo.EnglishName;
	                    Application.Current.MainPage = new NavigationPage(new SettingsPage())
	                    {
	                        BarBackgroundColor = SettingsHelper.GetGlobalNavigationBarColor(),
	                        BackgroundColor = SettingsHelper.GetGlobalBackGroundColor(),
	                    };
	                }
	                else
	                {
	                    Application.Current.MainPage.DisplayAlert("Language Not Selected", "Please Select Language", "Ok");
	                }

	            }



	        }
	        finally
	        {
	            App.Current.MainPage.Navigation.PopPopupAsync();

	        }
	    }
    }
}