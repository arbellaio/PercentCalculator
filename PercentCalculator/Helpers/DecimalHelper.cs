using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PercentCalculator.Helpers
{
    public static class DecimalHelper
    {
        public static decimal TruncateDecimal(decimal value, int precision)
        {
            decimal step = (decimal) Math.Pow(10, precision);
            decimal tmp = Math.Truncate(((decimal) (step * value)));
            return tmp / step;
        }

        public static decimal ThreeDecimal(decimal value)
        {
            var d = TruncateDecimal(value, 1);
            var a = d.ToString("0.0");
            var c = Convert.ToDecimal(a);
            return c;
        }


        public static string FormatString(decimal format)
        {
            NumberFormatInfo nfi = (NumberFormatInfo)
            CultureInfo.InvariantCulture.NumberFormat.Clone();
            var index = SettingsHelper.GetGlobalFormat();
            if (index == 0)
            {
                nfi.NumberGroupSeparator = " ";
                nfi.NumberDecimalSeparator = ".";
                var formattednumber = format.ToString("n", nfi);
                return formattednumber;
            }

            if (index  == 1)
            {
                nfi.NumberGroupSeparator = ",";
                nfi.NumberDecimalSeparator = ".";
                var formattednumber = format.ToString("n", nfi);
                return formattednumber;
            }

            if (index == 2)
            {
                nfi.NumberGroupSeparator = "";
                nfi.NumberDecimalSeparator = ".";
                var formattednumber = format.ToString("n", nfi);
                return formattednumber;
            }

            if (index == 3)
            {
                nfi.NumberGroupSeparator = " ";
                nfi.NumberDecimalSeparator = ",";
                var formattednumber = format.ToString("n", nfi);
                return formattednumber;
            }

            if (index == 4)
            {
                nfi.NumberGroupSeparator = ".";
                nfi.NumberDecimalSeparator = ",";
                var formattednumber = format.ToString("n", nfi);
                return formattednumber;
            }

            if (index == 5)
            {
                nfi.NumberGroupSeparator = "";
                nfi.NumberDecimalSeparator = ",";
                var formattednumber = format.ToString("n", nfi);
                return formattednumber;
            }

            return format.ToString();
        }

//        public static double TruncateDouble(double value, int digits)
//        {
//            double mult = System.Math.Pow(10.0, digits);
//            return System.Math.Truncate(value * mult) / mult;
//        }
    }
}