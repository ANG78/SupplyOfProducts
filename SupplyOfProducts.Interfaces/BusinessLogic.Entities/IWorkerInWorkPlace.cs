using System;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Entities
{
    public interface IWorkerInWorkPlace : IRequestMustBeCompleted,
                                          IContainWorkerProperty,
                                          IContainWorkPlaceProperty,
                                          ISupplyPeriod
    {
        int Id { get; set; }
        DateTime? DateFinish { get; set; }  
    }
}
