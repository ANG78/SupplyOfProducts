using SupplyOfProducts.Entities.BusinessLogic.Entities.Provision;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace SupplyOfProducts.PersistenceDDBB.Repository
{
    public class ProductSupplyRepository : GenericRepository<ProductSupply>, IGenericRepository<ProductSupply>, IProductSupplyRepository
    {
        public ProductSupplyRepository(IGenericContext dbContext) : base(dbContext)
        { }

        public IProductSupply Get(int id)
        {
            return _Current.FirstOrDefault(p => p.WorkerInWorkPlaceId == id);
        }

        public void Remove(IProductSupply obj)
        {
            if (obj.Id > 0)
            {
                _Current.Remove((ProductSupply)obj);
            }

        }

        public void Edit(IProductSupply obj)
        {
            base.Edit((ProductSupply)obj);
        }

        public void Add(IProductSupply obj)
        {
            base.Add((ProductSupply)obj);
        }

        public void Save(IProductSupplied obj)
        {
            base.Edit((ProductSupply)obj.ProductSupply);
        }


        public IEnumerable<IProductSupply> Get(string sCodeWorker)
        {
            return _Current.Where(x => x.WorkerInWorkPlace.Worker.Code == sCodeWorker)
               .Include(x => x.Product)
              //tbc .Include(x => x.ProductsSupplied).ThenInclude(y => ((ProductSupplied)y).ProductStock).ThenInclude(z => z.Product)
               .Include(x => x.WorkerInWorkPlace)
               .Include(x => x.WorkerInWorkPlace.Worker)
               .Include(x => x.WorkerInWorkPlace.WorkPlace)
               .OrderByDescending(x => x.Date)
               .Select(d => (IProductSupply)d).ToList();
        }

        public IEnumerable<IProductSupply> GetAll(string sCodeWorker)
        {
            return _Current.Where(x => x.WorkerInWorkPlace.Worker.Code == sCodeWorker)
                .Include(x => x.Product)
                //tbc.Include(x => x.ProductsSupplied).ThenInclude(y => ((ProductSupplied)y).ProductStock).ThenInclude(z => z.Product)
                .Include(x => x.WorkerInWorkPlace)
                .Include(x => x.WorkerInWorkPlace.Worker)
                .Include(x => x.WorkerInWorkPlace.WorkPlace)
                .OrderByDescending(x => x.PeriodDate)
                .Select(d => (IProductSupply)d)
                .ToList();
        }

        public IEnumerable<IProductSupply> Get()
        {
            return _Current
                .Include(x => x.Product)
                //tbc.Include(x => x.ProductsSupplied).ThenInclude(y => ((ProductSupplied)y).ProductStock).ThenInclude(z => z.Product)
                .Include(x => x.WorkerInWorkPlace)
                .Include(x => x.WorkerInWorkPlace.Worker)
                .Include(x => x.WorkerInWorkPlace.WorkPlace)
                .OrderByDescending(x => x.PeriodDate)
                .Select(d => (IProductSupply)d).ToList();
        }

        public IEnumerable<IProductSupply> GetAll(int idWorkerInWorkPlace, int idProduct, DateTime PeriodStartDate)
        {
            return _Current.Where(p => p.ProductId == idProduct &&
                                           p.WorkerInWorkPlaceId == idWorkerInWorkPlace &&
                                           p.PeriodDate == PeriodStartDate)
                        .Include(x => x.Product)
                        //tbc .Include(x => x.ProductsSupplied).ThenInclude(y => ((ProductSupplied)y).ProductStock).ThenInclude(z => z.Product)
                        .Include(x => x.WorkerInWorkPlace)
                        .Include(x => x.WorkerInWorkPlace.Worker)
                        .Include(x => x.WorkerInWorkPlace.WorkPlace)
                        .ToList();

        }

        public IEnumerable<IProductSupplied> GetProductSuppliedToWorkerOnThisPeriod(string sCodeProduct, string sCodeWorker, string sCodWorkPlace, DateTime date)
        {
            var result = _Current
                        .SelectMany(y => (IList < ProductSupplied >) y.ProductsSupplied)
                        .Where(p => p.ProductSupply.Product.Code == sCodeProduct &&
                                    p.ProductSupply.WorkerInWorkPlace.WorkPlace.Code == sCodWorkPlace &&
                                    p.ProductSupply.WorkerInWorkPlace.Worker.Code == sCodeWorker &&
                                    p.ProductSupply.PeriodDate == date)
                       .Include(x => x.ProductSupply)
                       .Include(x => x.ProductStock)
                       .ToList<IProductSupplied>();
           
            return result;
        }

        
    }
}
