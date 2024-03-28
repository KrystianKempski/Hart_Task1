using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hart_Task1.Common
{
    public static class CurrencyVat
    {
        public static readonly Dictionary<string, decimal> CurrencyVatList = new Dictionary<string, decimal>
        {
            { "PLN", 23 },
            { "EUR", 19 },
            { "GBP", 20 }
        };
    }
}
