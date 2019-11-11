using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.Repository;
using System;
using System.Linq;
using System.Collections.Generic;

namespace SupplyOfProducts.Persistance
{
    public class WorkerInWorkPlaceRepository : BaseRepository, IWorkerInWorkPlaceRepository
    {

        public WorkerInWorkPlaceRepository(MemoryContext context) : base(context)
        { }

        public void Add(IWorkerInWorkPlace item)
        {
            throw new NotImplementedException();
        }

        public void Edit(IWorkerInWorkPlace item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IWorkerInWorkPlace> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IWorkerInWorkPlace> Get(string code)
        {
            throw new NotImplementedException();
        }

        public IList<IWorkerInWorkPlace> GetWorkPlace(string sCodeWorker, DateTime? date)
        {

            if (!date.HasValue)
            {
                return Context.WorkerWorkPlaces.Where(x => x.Worker.Code == sCodeWorker).ToList();
            }
            else
            {
                var dateCompare = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day);

                return Context.WorkerWorkPlaces.Where(x => x.Worker.Code == sCodeWorker &&
                                                      x.DateStart < dateCompare &&
                                                      (!x.DateEnd.HasValue || x.DateEnd.Value >= dateCompare)).ToList();
            }

        }
    }
}
