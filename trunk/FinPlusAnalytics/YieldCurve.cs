using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinPlusAnalytics
{
    string YieldCurve(string marketName, string curveName, string discountCurveName, int settlementDate, string rates, string dayCount, double tolerance, string holidays)
    {
	    try 
	    {
	        std::vector<std::string> ratesVector = stringToVector(rates);
		    Calendar calendar = Holidays(holidays);
		    Date settleDate(settlementDate);
            settleDate = calendar.adjust(settleDate);
		    if(tolerance == 0)	tolerance = 1.0e-15;
		
		    std::vector<boost::shared_ptr<RateHelper>> instruments;

		    for each(std::string r in ratesVector)
		    {
			    boost::shared_ptr<RateHelper> rate = rateHelpers[marketName][r];
			    if(rate) instruments.push_back(rate);
		    }

		    rateCurves[marketName][curveName] = boost::shared_ptr<YieldTermStructure>(new PiecewiseYieldCurve<Discount,LogLinear>(settleDate, instruments, DayCount(dayCount), tolerance));
		
		    SwapEngine(marketName, curveName, discountCurveName == "" ? curveName : discountCurveName);

		    return curveName; 

	    }
	    catch (Exception e) 
	    {
		    return e.what();
	    }
    } 
}
