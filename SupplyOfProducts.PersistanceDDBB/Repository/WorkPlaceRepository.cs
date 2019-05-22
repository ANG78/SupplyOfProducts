using AutoMapper;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;

namespace SupplyOfProducts.PersistanceDDBB.Repository
{
    public class WorkPlaceRepository : GenericRepository<WorkPlace>, IWorkPlaceRepository
    {
        public WorkPlaceRepository(IGenericContext dbContext, IMapper mapper) : base(dbContext, mapper)
        { }

        public virtual IWorkPlace Get(string code)
        {
            return _Current.FirstOrDefault(x => x.Code == code);
        }

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

        public virtual IEnumerable<IWorkPlace> Get()
        {
            return _Current.ToList().OrderBy(x => x.Code);
        }

    }
}
