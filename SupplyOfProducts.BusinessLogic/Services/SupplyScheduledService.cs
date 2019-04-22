using System;
using System.Collections.Generic;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.Repository;

namespace SupplyOfProducts.BusinessLogic.Services
{
    public class SupplyScheduledService : ISupplyScheduledService
    {
        readonly ISupplyScheduledRepository _supplyScheduledRepository;
        public SupplyScheduledService(ISupplyScheduledRepository supplyScheduledRepository)
        {
            _supplyScheduledRepository = supplyScheduledRepository;
        }

        public ISupplyScheduled Get(string sProductCode, string sWorkerCode, string sWorkPlaceCode, DateTime date)
        {
           return _supplyScheduledRepository.Get( sProductCode,  sWorkerCode,  sWorkPlaceCode,  date);
        }

        public IList<ISupplyScheduled> Get(string sWorkerCode)
        {
           return _supplyScheduledRepository.Get(sWorkerCode);
        }

        public void Save(ISupplyScheduled objSch)
        {
            _supplyScheduledRepository.Save(objSch);
        }
    }
}
