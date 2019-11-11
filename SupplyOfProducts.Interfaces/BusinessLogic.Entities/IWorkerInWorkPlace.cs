using System;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Entities
{
    public interface IWorkerInWorkPlace : IContainWorkerProperty,
                                          IContainWorkPlaceProperty,
                                          IPeriod,
                                          IId
    {
    }
}
