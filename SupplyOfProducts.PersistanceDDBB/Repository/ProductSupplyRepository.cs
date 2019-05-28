using Microsoft.EntityFrameworkCore;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Provision;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SupplyOfProducts.PersistanceDDBB.Repository
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

      
        public IList<IProductSupply> GetProductSuppliedToWorker(string sCodeWorker)
        {
            return _Current.Where(x => x.WorkerInWorkPlace.Worker.Code == sCodeWorker)
                .Include(x => x.Product)
                .Include(x => x.ProductsSupplied).ThenInclude(y => ((ProductSupplied)y).ProductStock).ThenInclude(z => z.Product)
                .Include(x => x.WorkerInWorkPlace)
                .Include(x => x.WorkerInWorkPlace.Worker)
                .Include(x => x.WorkerInWorkPlace.WorkPlace)
                .OrderByDescending(x => x.Date)
                .Select(d => (IProductSupply)d).ToList();
        }


        public IProductSupply Get(string sCodeWorker)
        {
            return _Current.Where(x => x.WorkerInWorkPlace.Worker.Code == sCodeWorker)
                .Include(x => x.Product)
                .Include(x => x.ProductsSupplied).ThenInclude(y => ((ProductSupplied)y).ProductStock).ThenInclude(z=>z.Product)
                .Include(x => x.WorkerInWorkPlace)
                .Include(x => x.WorkerInWorkPlace.Worker)
                .Include(x => x.WorkerInWorkPlace.WorkPlace)
                .OrderByDescending(x => x.PeriodDate)
                .Select(d => (IProductSupply)d)
                .FirstOrDefault();
        }

        public IEnumerable<IProductSupply> Get()
        {
            return _Current
                .Include(x => x.Product)
                .Include(x => x.ProductsSupplied).ThenInclude(y => ((ProductSupplied)y).ProductStock).ThenInclude(z => z.Product)
                .Include(x => x.WorkerInWorkPlace)
                .Include(x => x.WorkerInWorkPlace.Worker)
                .Include(x => x.WorkerInWorkPlace.WorkPlace)
                .OrderByDescending(x => x.PeriodDate)
                .Select(d => (IProductSupply)d).ToList();
        }

        public IProductSupply Get(int idWorkerInWorkPlace, int idProduct, DateTime PeriodStartDate)
        {
            return _Current.Where(p => p.ProductId == idProduct &&
                                           p.WorkerInWorkPlaceId == idWorkerInWorkPlace &&
                                           p.PeriodDate == PeriodStartDate)
                        .Include(x => x.Product)
                        .Include(x => x.ProductsSupplied).ThenInclude(y => ((ProductSupplied)y).ProductStock).ThenInclude(z => z.Product)
                        .Include(x => x.WorkerInWorkPlace)
                        .Include(x => x.WorkerInWorkPlace.Worker)
                        .Include(x => x.WorkerInWorkPlace.WorkPlace)
                        .FirstOrDefault();

        }

        public IList<IProductSupplied> GetProductSuppliedToWorkerOnThisPeriod(string sCodeProduct, string sCodeWorker, string sCodWorkPlace, DateTime date)
        {
            return _Current.SelectMany(p => p.ProductsSupplied)
                            .Where(
                                    p => p.ParentProductSupplied == null &&
                                    p.ProductStock.Product.Code == sCodeProduct &&
                                    p.ProductSupply.WorkerInWorkPlace.Worker.Code == sCodeWorker &&
                                    p.ProductSupply.WorkerInWorkPlace.WorkPlace.Code == sCodWorkPlace &&
                                    p.ProductSupply.PeriodDate == date)
                            //.Include(x => x.ProductStock)
                            //.Include(x => x.ProductSupply)
                            //.Include(x => x.ParentProductSupplied)
                            .ToList();

        }


    }
}
