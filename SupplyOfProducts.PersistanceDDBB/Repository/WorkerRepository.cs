using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;

namespace SupplyOfProducts.PersistanceDDBB.Repository
{

    public class WorkerRepository : GenericRepository<Worker,IWorker>, IWorkerRepository
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

       
        
    }

}
