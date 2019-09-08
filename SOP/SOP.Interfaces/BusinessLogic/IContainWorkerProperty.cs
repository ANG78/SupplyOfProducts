using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.Interfaces.BusinessLogic
{
    public interface IContainWorkerProperty
    {
        int WorkerId { get; set; }
        IWorker Worker { get; set; }
    }

}
