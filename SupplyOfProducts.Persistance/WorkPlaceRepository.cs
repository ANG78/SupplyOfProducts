using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;

namespace SupplyOfProducts.Persistance
{
    public class WorkPlaceRepository : BaseRepository, IWorkPlaceRepository
    {
        public WorkPlaceRepository(MemoryContext context) : base(context)
        { }

        public void Add(IWorkPlace worker)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(IWorkPlace worker)
        {
            throw new System.NotImplementedException();
        }

        public IWorkPlace Get(string code)
        {
            return Context.WorkPlaces.FirstOrDefault(x => x.Code == code);
        }

        public IEnumerable<IWorkPlace> Get()
        {
            throw new System.NotImplementedException();
        }
    }
}
