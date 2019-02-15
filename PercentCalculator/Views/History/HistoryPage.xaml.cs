using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PercentCalculator.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PercentCalculator.Views.History
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HistoryPage : ContentPage
	{
		public HistoryPage ()
		{
			InitializeComponent ();
            var calc = new HistoryHelper();
		    var history = calc.GetCalculationHistory();
		}
	}
}