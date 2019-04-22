using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.Interfaces.BusinessLogic
{
    public interface IContainWorkerProperty
    {
        int IdWorker { get; set; }
        IWorker Worker { get; set; }
    }

}
