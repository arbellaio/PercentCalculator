using System;
using System.Linq;
using PercentCalculator.Constants;
using PercentCalculator.Helpers;
using PercentCalculator.Providers;
using PercentCalculator.Resources.Language;
using PercentCalculator.Views.Menu;
using PercentCalculator.Views.Settings;
using Plugin.Multilingual;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PercentCalculator
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //        
            if (Application.Current.Properties.ContainsKey(Keys.Language))
            {

                var selectedLanguage = CrossMultilingual.Current.NeutralCultureInfoList.ToList().First(element => element.EnglishName.Contains(Application.Current.Properties[Keys.Language].ToString()));
                if (selectedLanguage != null)
                {
                    CrossMultilingual.Current.CurrentCultureInfo = selectedLanguage;
                    AppResources.Culture = CrossMultilingual.Current.CurrentCultureInfo;
                    Application.Current.Properties[Keys.Language] = CrossMultilingual.Current.CurrentCultureInfo.EnglishName;
                }

            }
            MainPage = new NavigationPage(new MenuPage())
            {
                BarBackgroundColor = SettingsHelper.GetGlobalNavigationBarColor(),
                BackgroundColor = SettingsHelper.GetGlobalBackGroundColor()
            };


        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
