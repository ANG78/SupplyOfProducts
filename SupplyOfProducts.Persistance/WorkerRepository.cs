using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.Repository;
using System.Linq;

namespace SupplyOfProducts.Persistance
{
    public class WorkerRepository : BaseRepository, IWorkerRepository
    {
        public WorkerRepository(MemoryContext context) : base(context)
        { }

        public IWorker Get(string code)
        {
            return Context.Workers.FirstOrDefault(x => x.Code == code);
        }
    }

    




}
