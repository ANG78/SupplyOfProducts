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

        public void Save(IProductSupply obj)
        {
            if (obj.Id == 0)
            {
                Add((ProductSupply)obj);
            }
            else
            {
                Edit((ProductSupply)obj);
            }              
        }

        public void Remove(IProductSupply obj)
        {
            if (obj.Id > 0)
            {
                _Current.Remove((ProductSupply)obj);
            }

        }

        public void Save(IProductSupplied obj)
        {
            Edit((ProductSupply)obj.ProductSupply);
        }

        //public IList<IProductSupplied> GetByProductSupply(int idProductSupply)
        //{
        //    return _Current.SelectMany(p => p.ProductsSupplied)
        //            .Where(x => x.Id == idProductSupply).ToList();
        //}

        public IList<IProductSupply> GetProductSuppliedToWorker(string sCodeWorker)
        {
            return _Current.Where(x => x.WorkerInWorkPlace.Worker.Code == sCodeWorker)
                .OrderByDescending(x => x.PeriodDate)
                .Select(d=>(IProductSupply)d).ToList();
        }

        public IProductSupply Get(int idWorkerInWorkPlace, int idProduct, DateTime PeriodStartDate)
        {
            return _Current.FirstOrDefault( p => p.ProductId == idProduct &&
                                            p.WorkerInWorkPlaceId == idWorkerInWorkPlace &&
                                            p.PeriodDate == PeriodStartDate);

        }

        public IList<IProductSupplied> GetProductSuppliedToWorkerOnThisPeriod(string sCodeProduct, string sCodeWorker, string sCodWorkPlace, DateTime date)
        {
            return _Current.SelectMany(p => p.ProductsSupplied)
                            .Where(
                                    p => p.ParentProductSupplied == null &&
                                    p.ProductStock.Product.Code == sCodeProduct &&
                                    p.ProductSupply.WorkerInWorkPlace.Worker.Code == sCodeWorker &&
                                    p.ProductSupply.WorkerInWorkPlace.WorkPlace.Code == sCodWorkPlace &&
                                    p.ProductSupply.PeriodDate == date).ToList();
                                     
        }
    }
}
