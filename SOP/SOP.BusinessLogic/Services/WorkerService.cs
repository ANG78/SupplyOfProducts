using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.BusinessLogic.Services.Generics;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.Repository;

namespace SupplyOfProducts.BusinessLogic.Services
{


    public class WorkerService : GenericService<IWorker>, IWorkerService
    {

        public WorkerService(IWorkerRepository workerRepository) : base(workerRepository)
        {
        }

        public IResultObject<IWorker> CheckExist(string code)
        {
            var worker = _repository.Get(code);
            if (worker == null)
            {
                return new ResultObject<IWorker>(EnumResultBL.ERROR_USER_REQUIRED, code);
            }
            return new ResultObject<IWorker>(worker);
        }
        
    }
}
