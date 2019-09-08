using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.Repository;
using System.Collections.Generic;

namespace SupplyOfProducts.Persistance
{
    public class ConfigSupplyRepository : BaseRepository, IConfigSupplyRepository
    {
        public ConfigSupplyRepository(MemoryContext context) : base(context)
        { }

        public IEnumerable<IConfigSupply> Get(string code)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IConfigSupply> Get()
        {
            throw new System.NotImplementedException();
        }
    }
}
