using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stockquito.Models
{
    public class StocksModel
    {
        public IEnumerable<ETF> EtfList { get; set; }
    }
}
