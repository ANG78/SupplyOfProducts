using System;
using System.Collections.Generic;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.Repository;

namespace SupplyOfProducts.BusinessLogic.Services
{
    public class WorkerInWorkPlaceService : IWorkerInWorkPlaceService
    {
        readonly IWorkerInWorkPlaceRepository _repository;
        public WorkerInWorkPlaceService(IWorkerInWorkPlaceRepository workerRepository)
        {
            _repository = workerRepository;
        }

        public IEnumerable<IWorkerInWorkPlace> Get(string workercode)
        {
            return _repository.Get(workercode);
        }

        public IEnumerable<IWorkerInWorkPlace> GetAll()
        {
            return _repository.Get();
        }

        public IList<IWorkerInWorkPlace> GetWorkPlaceWhereWorkedTheWorker(string workerCode, DateTime? date)
        {
            return _repository.GetWorkPlace(workerCode, date);
        }

    }
}
