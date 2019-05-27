using System.Collections.Generic;
using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.Repository;

namespace SupplyOfProducts.BusinessLogic.Services
{
    public class WorkPlaceService : GenericServiceCode<IWorkPlace>, IWorkPlaceService
    {
        public WorkPlaceService(IWorkPlaceRepository workerRepository) : base(workerRepository)
        {

        }

        public IResultObject<IWorkPlace> CheckExist(string code)
        {
            var workPlace = _repository.Get(code);
            if (workPlace == null)
            {
                return new ResultObject<IWorkPlace>(EnumResultBL.ERROR_WORKPLACE_REQUIRED, code);
            }
            return new ResultObject<IWorkPlace>(workPlace);
        }

      
    }
}

