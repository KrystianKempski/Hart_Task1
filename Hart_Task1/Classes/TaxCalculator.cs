using Hart_Task1.Common;
using Hart_Task1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hart_Task1.Classes
{
    public class TaxCalculator : ITaxCalculator
    {
        private decimal _vatValue;
        
        public TaxCalculator(string? currency) 
        {
            _vatValue =  CurrencyVat.CurrencyVatList[currency] * 0.01m;
        }

        public decimal Calculate(decimal amount)
        {
            if(amount < 0.00m || _vatValue < 0.00m) 
            {
                return 0;
            }
            return Math.Round(amount * _vatValue,2);
        }
    }
}
