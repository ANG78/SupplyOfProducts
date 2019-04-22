using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.Interfaces.BusinessLogic
{
    public interface IContainWorkerInWorkPlaceProperty
    {
        int IdWorkerInWorkPlace { get; set; }
        IWorkerInWorkPlace WorkerInWorkPlace { get; set; }
    }
}
