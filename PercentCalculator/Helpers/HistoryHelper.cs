using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PercentCalculator.Helpers
{
    public sealed class HistoryHelper
    {
        private static HistoryHelper historyHelper = null;
        ObservableCollection<string> calcHistory = new ObservableCollection<string>();

        public HistoryHelper()
        {
        }

        public static HistoryHelper Instance
        {
            get
            {
                if (historyHelper == null)
                {
                    historyHelper = new HistoryHelper();
                }
                return historyHelper;
            }
        }

        public ObservableCollection<string> CalculationHistory(string calculation)
        {
            calcHistory.Add(calculation);
            return calcHistory;
        }
        public ObservableCollection<string> GetCalculationHistory()
        {
            return calcHistory;
        }
    }
}
