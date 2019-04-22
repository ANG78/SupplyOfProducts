using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.Repository;
using System;
using System.Collections.Generic;
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

        public IList<IWorkerInWorkPlace> GetWorkPlace(string sCodeWorker, DateTime? date)
        {
            if (!date.HasValue)
            {
                return Context.WorkerWorkPlaces.Where(x => x.Worker.Code == sCodeWorker).ToList();
            }
            else
            {
                var dateCompare = new DateTime( date.Value.Year, date.Value.Month,date.Value.Day);
                
                return Context.WorkerWorkPlaces.Where(x => x.Worker.Code == sCodeWorker && 
                                                      x.DateStart < dateCompare &&
                                                      (!x.DateFinish.HasValue || x.DateFinish.Value >= dateCompare)).ToList();
            }
            
        }
    }

   

    
}
