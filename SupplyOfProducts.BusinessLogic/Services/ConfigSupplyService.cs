using System.Collections.Generic;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.Repository;

namespace SupplyOfProducts.BusinessLogic.Services
{
    public class ConfigSupplyService :  IConfigSupplyService
    {

        protected readonly IConfigSupplyRepository _repository;
        public ConfigSupplyService(IConfigSupplyRepository pRepository) 
        {
            _repository = pRepository;
        }

        public IEnumerable<IConfigSupply> Get(string code)
        {
           return _repository.Get(code);
        }

        public IEnumerable<IConfigSupply> GetAll()
        {
            return _repository.Get();
        }
    }

    

}
