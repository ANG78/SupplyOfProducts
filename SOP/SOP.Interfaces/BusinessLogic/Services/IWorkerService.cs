using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.Interfaces.BusinessLogic.Services
{

    public interface IWorkerService : IGenericService<IWorker>
    {
        IResultObject<IWorker> CheckExist(string code);
    }
}
