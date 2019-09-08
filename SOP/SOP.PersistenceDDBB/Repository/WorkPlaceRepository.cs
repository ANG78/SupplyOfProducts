using AutoMapper;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.Repository;
using System.Linq;

namespace SupplyOfProducts.PersistenceDDBB.Repository
{
    public class WorkPlaceRepository : GenericRepository<WorkPlace, IWorkPlace>, IWorkPlaceRepository
    {
        public WorkPlaceRepository(IGenericContext dbContext, IMapper mapper) : base(dbContext, mapper)
        { }
        

        public virtual void Add(IWorkPlace worker)
        {
            if (worker is WorkPlace)
            {
                base.Add((WorkPlace)worker);
            }
            else
            {
                var mapped = Mapper.Map<WorkPlace>(worker);
                base.Add(mapped);
            }
        }
        
        public virtual void Edit(IWorkPlace worker)
        {
            var copy = _Current.FirstOrDefault(x => x.Id == worker.Id);
            copy.Code = worker.Code;

            base.Edit(copy);

        }
        
    }
}
