using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SupplyOfProducts.Persistance
{
    public class SupplyScheduledRepository : BaseRepository, ISupplyScheduledRepository
    {
        public SupplyScheduledRepository(MemoryContext context) : base(context)
        {
        }

        public ISupplyScheduled Get(string sProductCode, string sWorkerCode, string sWorkPlaceCode, DateTime date)
        {
           return Context.SuppliesScheduled.FirstOrDefault(x => x.WorkerInWorkPlace.Worker.Code == sWorkerCode &&
                                                         x.Product.Code == sProductCode &&
                                                         x.WorkerInWorkPlace.WorkPlace.Code == sWorkPlaceCode &&
                                                         x.PeriodDate == date);
        }

        public IList<ISupplyScheduled> Get(string sWorkerCode)
        {
            return Context.SuppliesScheduled.Where(x => x.WorkerInWorkPlace.Worker.Code == sWorkerCode ).ToList();
        }

        public void Save(ISupplyScheduled objSch)
        {
            if (objSch.Id == 0)
            {
                objSch.Id = MemoryContext.IdInternal;
                Context.SuppliesScheduled.Add(objSch);
            }

            objSch.ProductId = objSch.Product.Id;
            objSch.WorkerInWorkPlaceId = objSch.WorkerInWorkPlace.Id;
            
        }
    }
}
