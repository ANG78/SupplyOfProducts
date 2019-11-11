using System;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Entities
{
    public interface IPeriod : ISupplyPeriod
    {
        DateTime? DateEnd { get; set; }
    }
}
