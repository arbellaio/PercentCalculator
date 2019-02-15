using System;
using System.Collections.Generic;
using System.Text;
using PercentCalculator.Helpers;
using Xamarin.Forms;

namespace PercentCalculator.ViewModels.SubViews
{
    public class SubViewModel : BaseViewModel
    {
        public Color _textColor = SettingsHelper.GetGlobalTextColor();
        public Color TextColor
        {
            get => _textColor;
            set { _textColor = value; OnPropertyChanged(nameof(TextColor)); }
        }
    }
}
