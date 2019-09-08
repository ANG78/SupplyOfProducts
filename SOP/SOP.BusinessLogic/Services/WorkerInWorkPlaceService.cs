using System;
using System.Collections.Generic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.Repository;

namespace SupplyOfProducts.BusinessLogic.Services
{
    public class WorkerInWorkPlaceService : IWorkerInWorkPlaceService
    {
        readonly IWorkerInWorkPlaceRepository _workerRepository;
        public WorkerInWorkPlaceService(IWorkerInWorkPlaceRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }

        public IList<IWorkerInWorkPlace> GetWorkPlaceWhereWorkedTheWorker(string workerCode, DateTime? date)
        {
            return _workerRepository.GetWorkPlace(workerCode, date);
        }

    }
}
