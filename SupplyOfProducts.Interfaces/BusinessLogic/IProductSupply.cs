using System.Collections.Generic;

namespace SupplyOfProducts.Interfaces.BusinessLogic
{

    public interface IProductSupply : IContainDatePeriodProperty,
                                      IContainWorkerInWorkPlaceProperty, 
                                      IContainProductProperty
    {
        int Id { get; set; }
        IList<IProductSupplied> ProductsSupplied { get; set; } 
    }
}
