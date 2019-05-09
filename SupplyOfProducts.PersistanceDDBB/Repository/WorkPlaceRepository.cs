using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.Repository;
using System.Linq;

namespace SupplyOfProducts.PersistanceDDBB.Repository
{
    public class WorkPlaceRepository : GenericRepository<WorkPlace>, IWorkPlaceRepository
    {
        public WorkPlaceRepository(IGenericContext dbContext) : base(dbContext)
        { }

        public IWorkPlace Get(string code)
        {
            return _Current.FirstOrDefault(x => x.Code == code);
        }

        
    }
}
