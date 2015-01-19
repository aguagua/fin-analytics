using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinPlusAnalytics
{
    public class Markets
    {
        private static IDictionary<string, Market> _markets;

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
    }
}
