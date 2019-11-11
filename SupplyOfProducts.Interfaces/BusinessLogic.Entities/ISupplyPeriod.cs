using System;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Entities
{
    public interface ISupplyPeriod
    {
        DateTime DateStart { get; set; }
        int NumYearsByPeriod { get; set; }
    }
}
