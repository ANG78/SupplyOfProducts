using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.BusinessLogic
{

    public interface IProductSupply : IContainDatePeriodProperty,
                                      IContainWorkerInWorkPlaceProperty, 
                                      IContainProductProperty,
                                      IId
    {
        IList<IProductSupplied> ProductsSupplied { get; set; } 
    }
}
