using System;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Entities
{
    public interface IWorkerInWorkPlace : IContainWorkerProperty,
                                          IContainWorkPlaceProperty,
                                          ISupplyPeriod
    {
        int Id { get; set; }
        DateTime? DateEnd { get; set; }  
    }
}
