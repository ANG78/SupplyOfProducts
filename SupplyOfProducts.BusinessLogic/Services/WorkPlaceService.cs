using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.Repository;

namespace SupplyOfProducts.BusinessLogic.Services
{
    public class WorkPlaceService : IWorkPlaceService
    {
        readonly IWorkPlaceRepository _workPlaceRepository;
        public WorkPlaceService(IWorkPlaceRepository workerRepository)
        {
            _workPlaceRepository = workerRepository;
        }

        public IResultObject<IWorkPlace> Get(string code)
        {
            var workPlace = _workPlaceRepository.Get(code);
            if (workPlace == null)
            {
                return new ResultObject<IWorkPlace>(EnumResultBL.ERROR_WORKPLACE_REQUIRED, code);
            }
            return new ResultObject<IWorkPlace>(workPlace);
        }
    }
}

