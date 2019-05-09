using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.Interfaces.Repository
{
    public interface IWorkerRepository
    {
        IWorker Get(string code);
        
    }
}
