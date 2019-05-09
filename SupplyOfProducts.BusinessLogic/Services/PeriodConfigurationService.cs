using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using System;

namespace SupplyOfProducts.BusinessLogic.Services
{
    public class PeriodConfigurationService : IPeriodConfigurationService
    {
        public PeriodConfigurationService()
        {
            
        }


        public IResultObject<DateTime> ComputeDate(ISupplyPeriod period, DateTime date)
        {
            if (date < period.DateStart)
            {
                return new ResultObject<DateTime>(EnumResultBL.ERROR_PERIODDATE_NOT_POSSIBLE_TO_BE_CALCULATED, date, period.DateStart) ;
            }

            if ( period.NumYearsByPeriod == 0)
            {
                return new ResultObject<DateTime>(EnumResultBL.ERROR_NUM_YEARS_BY_PERIOD_IS_ZERO, date, period.DateStart);
            }

            var numDays = (int)(date - period.DateStart).TotalDays;

            int numDaysPeriod = 365 * period.NumYearsByPeriod;

            var numPeriod = (int)Math.Truncate((double) numDays / numDaysPeriod);

            var result = period.DateStart.AddYears((int)(numPeriod * period.NumYearsByPeriod));

            return new ResultObject<DateTime>(result);

        }
    }
}
