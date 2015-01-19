using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinPlusAnalytics
{
    public class Market
    {
        public string Name { get; private set; } 
        
        private IDictionary<string, YieldCurve> _yieldCurves; 

        public Market(string name) 
        {
            Name = name;
        }
    }
}
