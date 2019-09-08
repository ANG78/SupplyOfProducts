
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace SupplyOfProducts.PersistenceDDBB.Repository
{
    public class WorkerInWorkPlaceRepository : GenericRepository<WorkerInWorkPlace>, IWorkerInWorkPlaceRepository
    {
        public WorkerInWorkPlaceRepository(IGenericContext dbContext) : base(dbContext)
        { }

        public IList<IWorkerInWorkPlace> GetWorkPlace(string sCodeWorker, DateTime? date)
        {
            if (!date.HasValue)
            {
                var result = _Current
                                .Include(x=>x.WorkerEF)
                                .Include(x => x.WorkPlaceEF)
                                .Where(x => x.WorkerEF.Code == sCodeWorker)
                                .ToList();
                return result.Select(y => (IWorkerInWorkPlace)y).ToList();
            }
            else
            {
                var dateCompare = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day);

                return _Current.Include(x => x.WorkerEF)
                                .Include(x => x.WorkPlaceEF)
                                .Where(x => x.WorkerEF.Code == sCodeWorker &&
                                                      x.DateStart < dateCompare &&
                                                      (!x.DateEnd.HasValue || x.DateEnd.Value >= dateCompare))
                                                        .Select(x=> (IWorkerInWorkPlace) x).ToList();
            }

        }

    }
}
