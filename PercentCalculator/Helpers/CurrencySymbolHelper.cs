using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PercentCalculator.Helpers
{
    public class CurrencySymbolHelper
    {
        public static string GetCurrencySymbol(string code)
        {
                var regionInfo = (from culture in CultureInfo.GetCultures(CultureTypes.AllCultures)
                where culture.Name.Length > 0 && !culture.IsNeutralCulture
                let region = new RegionInfo(culture.LCID)
                where string.Equals(region.ISOCurrencySymbol, code, StringComparison.InvariantCultureIgnoreCase)
                select region).FirstOrDefault();
                if (regionInfo == null)
                {
                  var regionInfoObj = new RegionInfo(CultureInfo.CurrentCulture.LCID);
                  return regionInfoObj.CurrencySymbol;
                }
            return regionInfo.CurrencySymbol;
        }
    }
}
