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
        private double _vatValue;
        
        public TaxCalculator(string? currency) 
        {
            _vatValue =  (double)CurrencyVat.CurrencyVatList[currency] * 0.01;
        }

        public decimal Calculate(decimal amount)
        {
            if(amount < 1 || _vatValue < 0.0) 
            {
                return 0;
            }
            return (decimal)Math.Round((double)amount * _vatValue);
        }
    }
}
