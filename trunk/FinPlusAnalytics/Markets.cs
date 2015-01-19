using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinPlusAnalytics
{
    public class Markets
    {
        private static volatile Markets _instance;
        private static object _lock = new Object();
        private IDictionary<string, Market> _markets;

        public Markets()
        {
            _markets = new Dictionary<string, Market>();
        }

        public Market Market(string name)
        {
            Market market = null;

            lock (_markets)
            {
                if (!_markets.ContainsKey(name))
                    _markets[name] = market = new Market(name);
                else
                    market = _markets[name];
            }

            return market;
        }

        public static Markets Instance
        {
            get 
            {
                if (_instance == null) 
                {
                    lock (_lock) 
                    {
                        if (_instance == null) 
                            _instance = new Markets();
                    }
                }

                return _instance;
            }
        }
    }
}
