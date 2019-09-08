using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<IConfigSupply> GetAll(string code)
        {
           return _repository.Get(code);
        }

        public IEnumerable<IConfigSupply> GetAll()
        {
            return _repository.Get();
        }

        public IEnumerable<IConfigSupply> Get(string code)
        {
            return _repository.Get(code).OrderByDescending(x=>x.Date);
        }
    }

    

}
