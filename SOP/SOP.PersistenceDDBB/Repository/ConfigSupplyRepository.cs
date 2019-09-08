using AutoMapper;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SupplyOfProducts.PersistenceDDBB.Repository
{
    public class ConfigSupplyRepository : GenericRepository<ConfigSupply>, IGenericRepository<ConfigSupply>, IConfigSupplyRepository
    {

        private readonly IMapper _mapper;
        public ConfigSupplyRepository(IGenericContext dbContext, IMapper m) : base(dbContext)
        {
            _mapper = m;
        }

        public IEnumerable<IConfigSupply> Get(string WorkerCode)
        {
            var result = _Current
                          .Where(x=>x.WorkerInWorkPlace.Worker.Code == WorkerCode)
                           .Include(x => x.Product)
                           .Include(x => x.WorkerInWorkPlace)
                           .Include(x => x.WorkerInWorkPlace.Worker)
                           .Include(x => x.WorkerInWorkPlace.WorkPlace)
                           .Include(x => x.SupplyScheduled)
                          .ToList();

            return (result);
        }

        public IEnumerable<IConfigSupply> Get()
        {
            var result = _Current            
                           .Include(x => x.Product)
                           .Include(x => x.WorkerInWorkPlace)
                           .Include(x => x.WorkerInWorkPlace.Worker)
                           .Include(x => x.WorkerInWorkPlace.WorkPlace)
                           .Include(x => x.SupplyScheduled)
                           .ToList();

            return (result);
        }
    }
}