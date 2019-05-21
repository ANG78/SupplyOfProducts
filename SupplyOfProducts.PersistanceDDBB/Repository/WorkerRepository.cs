using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;

namespace SupplyOfProducts.PersistanceDDBB.Repository
{

    public class WorkerRepository : GenericRepository<Worker>, IWorkerRepository
    {
        public WorkerRepository(IGenericContext dbContext) : base(dbContext)
        { }

        public virtual void Add(IWorker worker)
        {
            if (worker is Worker)
            {
                base.Add((Worker)worker);
            }
            else
            {
                base.Add(new Worker(worker));
            }         
        }

        public virtual void Edit(IWorker worker)
        {
            var copy = _Current.FirstOrDefault(x => x.Id == worker.Id);
            copy.Name = worker.Name;
            copy.Code = worker.Code;

            base.Edit(copy);
            
        }

        public virtual IWorker Get(string code)
        {
            return _Current.FirstOrDefault(x => x.Code == code);
        }

        public virtual IEnumerable<IWorker> Get()
        {
            return _Current.ToList().OrderBy(x => x.Code);
        }
    }

}
