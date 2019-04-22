using System;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Entities
{
    public interface ISupplyPeriod
    {
        DateTime DateStart { get; set; }
        uint NumYearsByPeriod { get; set; }
    }
}

