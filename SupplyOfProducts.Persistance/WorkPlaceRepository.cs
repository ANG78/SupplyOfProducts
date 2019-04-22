using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.Repository;
using System.Linq;

namespace SupplyOfProducts.Persistance
{
    public class WorkPlaceRepository : BaseRepository, IWorkPlaceRepository
    {
        public WorkPlaceRepository(MemoryContext context) : base(context)
        { }

        public IWorkPlace Get(string code)
        {
            return Context.WorkPlaces.FirstOrDefault(x => x.Code == code);
        }
    }
}
