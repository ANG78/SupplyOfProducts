using System;
using System.Collections.Generic;
using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.Repository;

namespace SupplyOfProducts.BusinessLogic.Services
{
    public class WorkerService : IWorkerService
    {
        readonly IWorkerRepository _workerRepository;
        public WorkerService(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }

        public IResultObject<IWorker> Get(string code)
        {
            var worker = _workerRepository.Get(code);
            if (worker == null)
            {
                return new ResultObject<IWorker>(EnumResultBL.ERROR_USER_REQUIRED, code);
            }
            return new ResultObject<IWorker>(worker);
        }
    }


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
