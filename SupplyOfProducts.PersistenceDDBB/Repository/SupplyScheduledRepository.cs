using Microsoft.EntityFrameworkCore;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Provision;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SupplyOfProducts.PersistanceDDBB.Repository
{
    public class SupplyScheduledRepository : GenericRepository<SupplyScheduled>, ISupplyScheduledRepository
    {
        public SupplyScheduledRepository(IGenericContext dbContext) : base(dbContext)
        {
        }

        public ISupplyScheduled Get(string sProductCode, string sWorkerCode, string sWorkPlaceCode, DateTime date)
        {
            return _Current
                    .Include(x=> x.Product)
                    .Include(x => x.WorkerInWorkPlace).ThenInclude(y => y.Worker)
                    .Include(x => x.WorkerInWorkPlace.Worker)
                    .Include(x => x.WorkerInWorkPlace.WorkPlace)
                    .Where(x => x.WorkerInWorkPlace.Worker.Code == sWorkerCode &&
                                                          x.Product.Code == sProductCode &&
                                                          x.WorkerInWorkPlace.WorkPlace.Code == sWorkPlaceCode &&
                                                          x.PeriodDate == date)
                                                          .FirstOrDefault();
        }

        public IList<ISupplyScheduled> Get(string sWorkerCode)
        {
            return _Current
                .Include(x => x.Product)
                    .Include(x => x.WorkerInWorkPlace)
                    .Include(x => x.WorkerInWorkPlace.Worker)
                    .Include(x => x.WorkerInWorkPlace.WorkPlace)
                .Where(x => x.WorkerInWorkPlace.Worker.Code == sWorkerCode).Select(y=>(ISupplyScheduled)y).ToList();
        }

        public void Save(ISupplyScheduled objSch)
        {
            SupplyScheduled supl = (SupplyScheduled)objSch;
            
            if (objSch.Id == 0)
            {    
                base.Add(supl);
            }
            else
            {
                base.Edit(supl);
            }
        }
    }
}
