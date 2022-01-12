using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stockquito.Models
{
    public class ETF
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Exchange { get; set; }
        public string ExchangeShortName { get; set; }

    }
}
