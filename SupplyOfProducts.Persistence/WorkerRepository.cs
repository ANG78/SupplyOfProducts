using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;

namespace SupplyOfProducts.Persistance
{
    public class WorkerRepository : BaseRepository, IWorkerRepository
    {
        public WorkerRepository(MemoryContext context) : base(context)
        { }

        public void Add(IWorker worker)
        { 
            Context.Workers.Add(worker);
        }

        public void Edit(IWorker worker)
        {
            var res = Context.Workers.Where(x => x.Code == worker.Code).FirstOrDefault();
            Context.Workers.Remove(res);

            worker.Id = res.Id;
            Context.Workers.Add(worker);
        }

        public IWorker Get(string code)
        {
            return Context.Workers.FirstOrDefault(x => x.Code == code);
        }

        public IEnumerable<IWorker> Get()
        {
            return Context.Workers.ToList().OrderBy(x => x.Code);
        }
    }






}
