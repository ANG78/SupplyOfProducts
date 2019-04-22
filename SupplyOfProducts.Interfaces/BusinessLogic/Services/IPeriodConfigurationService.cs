using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Services
{
    public interface IPeriodConfigurationService
    {
        IResultObject<DateTime> ComputeDate(ISupplyPeriod period, DateTime date);
    }
}
