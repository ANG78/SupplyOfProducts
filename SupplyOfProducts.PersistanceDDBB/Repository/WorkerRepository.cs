using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.Repository;
using System.Linq;

namespace SupplyOfProducts.PersistanceDDBB.Repository
{

    public class WorkerRepository : GenericRepository<Worker>, IWorkerRepository
    {
        public WorkerRepository(IGenericContext dbContext) : base(dbContext)
        { }

        public IWorker Get(string code)
        {
            return _Current.FirstOrDefault(x => x.Code == code);
        }

    }

}
