using System;
using System.Collections.Generic;
using System.Text;

namespace PercentCalculator.Helpers
{
    public class FormulasHelper
    {
        // Percentage Calculator Formula
        public static decimal Formula1(decimal value1, decimal value2)
        {
            return DecimalHelper.ThreeDecimal((value1 * value2) / 100);
        }

        // Percentage Increase Formula
        public static decimal Formula2(decimal value1, decimal value2)
        {
            return DecimalHelper.ThreeDecimal((value1 * (100 + value2)) / 100);
        }

        // Discount Formula
        public static decimal Formula3(decimal value1, decimal value2)
        {
            return DecimalHelper.ThreeDecimal(value1 - (value1 * value2) / 100);
        }
        
        // Percentage Of Formula
        public static decimal Formula4(decimal value1, decimal value2)
        {
            return DecimalHelper.ThreeDecimal((value1 / value2) * 100);
        }

        // Percentage Change Formula
        public static decimal Formula5(decimal value1, decimal value2)
        {
            return DecimalHelper.ThreeDecimal(((value2 - value1) / value1) * 100);
        }

        // Tip Formula
        public static (decimal,decimal,decimal)  Formula6(decimal value1, decimal value2, decimal value3)
        {
            var tipAmount = DecimalHelper.ThreeDecimal((value1 * value3) / 100);
            var totalToPay = DecimalHelper.ThreeDecimal( value1 + tipAmount);
            var totalPerPerson = DecimalHelper.ThreeDecimal(totalToPay / value2);
           
            return (tipAmount, totalToPay, totalPerPerson);
        }

        // Margin Formula - Value 1 => Cost, Value 2 => Margin %
        public static decimal Formula7(decimal value1, decimal value2)
        {
            value2 = value2 / 100;
            return DecimalHelper.ThreeDecimal(value1 / (1 - value2));
        }

        // MarkUp / Margin / Revenue / Profit All in One Formula - Value 1 => Cost & Value 2 => Markup %
        public static (decimal,decimal,decimal) Formula8(decimal value1, decimal value2)
        {
            value2 = DecimalHelper.ThreeDecimal(value2 / 100);
            var profit = DecimalHelper.ThreeDecimal(value2 * value1);
            var revenue = DecimalHelper.ThreeDecimal(value1 + profit);
            var marginValue = DecimalHelper.ThreeDecimal(1 - (value1 / revenue));
            var marginPercentage = DecimalHelper.ThreeDecimal(marginValue * 100);
            return (marginPercentage,revenue,profit);
        }

        // SalesTax / ( Gross Price and Sales Tax Amount) value 1 => Net Amount & Value 2 => Sales Tax %
        public static (decimal, decimal) Formula9(decimal value1, decimal value2)
        {
            var salesTaxAmount = DecimalHelper.ThreeDecimal(value2 * (value1 / 100));
            var grossPrice = DecimalHelper.ThreeDecimal(value2 + salesTaxAmount);
            return (grossPrice, salesTaxAmount);
        }

        // Convert Fraction To Percentage
        public static decimal Formula10(decimal value1, decimal value2)
        {
            var percentage = DecimalHelper.ThreeDecimal((value1 / value2) * 100);
            return percentage;
        }

        // Compound Interest Value 1 => Initial Amount and Value 2 => Interest Rate & Value 3 => No. of years & Value 4 Compound Value
        public static decimal Formula11(decimal value1, double value2, double value3, double value4)
        {
            var compoundInterest = ((decimal) (Math.Pow((1 + ((value2/100) / value4)), (value3 * value4))));
            var amount = DecimalHelper.ThreeDecimal(value1 * ((decimal)(Math.Pow((1 + ((value2 / 100) / value4)), (value3 * value4)))));
            return amount;
        }

      


        // Doubling Time 70 / 2
        public static decimal Formula13(decimal value1)
        {
            var doublingPeriod = DecimalHelper.ThreeDecimal(70 / value1);
            return doublingPeriod;
        }

        // Inflation Value 1 => Inflation % & Value 2 => Start Year & Value 3 => End Year & Value 4 => Initial Value
        public static (decimal, decimal) Formula14(decimal value1, decimal value2, decimal value3, decimal value4)
        {
            var finalValue = DecimalHelper.ThreeDecimal(((value1 / 100) + 1) * value4);
            var timePeriod = DecimalHelper.ThreeDecimal(value3 - value2);
            finalValue = DecimalHelper.ThreeDecimal(finalValue * timePeriod);
            var difference = DecimalHelper.ThreeDecimal(finalValue - value4);

            return (finalValue, difference);
        }

        // Cumulative Growth Percentage Value1 => Growth % & Value2 => Periods & Value3 => Initial Value
        public static (decimal, decimal,decimal) Formula15(double value1, double value2, double value3)
        {
            var finalValue = DecimalHelper.ThreeDecimal((decimal)(value3 * (Math.Pow((1 + (value1/100)),value2))));
            var difference = DecimalHelper.ThreeDecimal(finalValue - (decimal)value3);
            var totalGrowthPercentage = DecimalHelper.ThreeDecimal((difference / (decimal)value3) * 100);
            return (finalValue, difference,totalGrowthPercentage);
        }

        // Loan Payment 
        public static decimal Formula16(decimal presentValue, decimal ratePerPeriod, decimal numberOfPeriods)
        {
            return (ratePerPeriod * presentValue) / (1 - (decimal)Math.Pow((double)(1 + ratePerPeriod), (double)-numberOfPeriods));
        }

        //  Vat Tax Value 1 => Net Amount & Value 2 => Tax %
        public static (decimal, decimal) Formula12(decimal value1, decimal value2)
        {
            var vatpercentage = value2 / 100;
            var vatamount = DecimalHelper.ThreeDecimal((value1 * vatpercentage));
            var amountaftertax = value1 + vatamount;
            return (amountaftertax, vatamount);
        }

        // value 1 is vat % and value 2 is net amount and value 3 is margin %
        public static (decimal, decimal,decimal,decimal) Formula17(decimal value1, decimal value2, decimal value3)
        {
            var vatpercentage = value1 / 100;
            var vatamount = DecimalHelper.ThreeDecimal((value2 * vatpercentage));
            var grosscost = value2 + vatamount;
            var marginamount = value3 / 100;
            var netprice = DecimalHelper.ThreeDecimal(value2 / (1 - marginamount));
            var grossprice = DecimalHelper.ThreeDecimal(grosscost / (1 - marginamount));
            var profit = netprice - value2;

            return (grosscost, netprice, grossprice, profit);
        }


        // value1 is cost / value2 is margin % / value3 is sales tax %
        public static (decimal, decimal, decimal) Formula18(decimal value1, decimal value2, decimal value3)
        {
            value2 = value2 / 100;
            var netprice = DecimalHelper.ThreeDecimal(value1 / (1 - value2));

            var salesTaxAmount = DecimalHelper.ThreeDecimal(value3 * (netprice / 100));
            var grossPrice = DecimalHelper.ThreeDecimal(netprice + salesTaxAmount);

            return (netprice, grossPrice, salesTaxAmount);
        }
    }
}
                  