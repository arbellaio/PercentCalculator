using System;
using System.Collections.Generic;
using System.Text;
using PercentCalculator.Colors;
using PercentCalculator.Constants;
using Xamarin.Forms;

namespace PercentCalculator.Helpers
{
    public class SettingsHelper
    {
        public static Color GetGlobalNavigationBarColor()
        {
            if (Application.Current.Properties.ContainsKey(Keys.NavigationBarColor))
            {
                var colorCode = Application.Current.Properties[Keys.NavigationBarColor].ToString();
                var color = Color.FromHex(colorCode);
                return color;
            }

            return NormalNavigationColor();
        }

        public static string GetGlobalCurrencySymbol()
        {
            if (Application.Current.Properties.ContainsKey(Keys.CurrencySymbol))
            {
                var currencySymbol = Application.Current.Properties[Keys.CurrencySymbol].ToString();
                return currencySymbol;
            }

            return "$";
        }

        public static string GetGlobalLanguage()
        {
            if (Application.Current.Properties.ContainsKey(Keys.Language))
            {
                var language = Application.Current.Properties[Keys.Language].ToString();
                return language;
            }

            return "en";
        }
        public static Color GetGlobalBackGroundColor()
        {
            if (Application.Current.Properties.ContainsKey(Keys.BackgroundColor))
            {
                var colorCode = Application.Current.Properties[Keys.BackgroundColor].ToString();
                var color = Color.FromHex(colorCode);
                return color;
            }

            return NormalBackgroundColor();
        }

        public static Color GetGlobalTextColor()
        {
            if (Application.Current.Properties.ContainsKey(Keys.TextColor))
            {
                var colorCode = Application.Current.Properties[Keys.TextColor].ToString();
                var color = Color.FromHex(colorCode);
                return color;
            }

            return Color.Black;
        }
        public static Color DarkModeBackgroundColor()
        {
            var color = Color.FromHex(AppColors.DarkModeBackgroundColor);
            return color;
        }

        public static Color DarkModeNavigationBarColor()
        {
            var color = Color.FromHex(AppColors.DarkModeNavBarColor);
            return color;
        }

        public static Color NormalBackgroundColor()
        {
            var color = Color.FromHex(AppColors.NormalBackgroundColor);
            return color;
        }

        public static Color NormalNavigationColor()
        {
            var color = Color.FromHex(AppColors.NormalNavBarColor);
            return color;
        }

        public static int GetGlobalFormat()
        {
            if (Application.Current.Properties.ContainsKey(Keys.Format))
            {
                var language = Application.Current.Properties[Keys.Format].ToString();
                return Convert.ToInt32(language);
            }

            return 0;
        }

    }

}
