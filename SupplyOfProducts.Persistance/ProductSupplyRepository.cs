using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SupplyOfProducts.Persistance
{
    public class ProductSupplyRepository : BaseRepository, IProductSupplyRepository
    {
        public ProductSupplyRepository(MemoryContext context) : base(context)
        { }
        
        public IProductSupply Get(int id)
        {
            return Context.ProductsSupply.FirstOrDefault(p => p.IdWorkerInWorkPlace == id);
        }

        public void Save(IProductSupply obj)
        {
            if (obj.Id == 0)
            {
                obj.Id = MemoryContext.IdInternal;
                Context.ProductsSupply.Add(obj);
            }

            if (obj.ProductSupplied != null)
            {
                if (obj.ProductSupplied.Id == 0)
                {
                    obj.ProductSupplied.Id = MemoryContext.IdInternal;
                    Context.ProductsSupplied.Add(obj.ProductSupplied);
                }

                obj.ProductSupplied.IdProductSupply = obj.IdWorkerInWorkPlace;
                obj.ProductSupplied.IdProductStock = obj.ProductSupplied.ProductStock.Id;
                obj.IdProductSupplied = obj.ProductSupplied.Id;
            }
        }

        public void Remove(IProductSupply obj)
        {
            if (obj.Id > 0)
            {
                Context.ProductsSupply.Remove(obj);
            }

            if (obj.ProductSupplied != null && obj.ProductSupplied.Id > 0)
            {
                Context.ProductsSupplied.Remove(obj.ProductSupplied);
            }
        }

        public void Save(IProductSupplied obj)
        {
            obj.Id = MemoryContext.IdInternal;
            Context.ProductsSupplied.Add(obj);
        }
        
        public IProductSupplied GetByProductSupply(int idProductSupply)
        {
            return Context.ProductsSupplied.FirstOrDefault(x => x.ProductSupply.IdWorkerInWorkPlace == idProductSupply);
        }

        public IList<IProductSupply> GetProductSuppliedToWorker(string sCodeWorker)
        {
            return Context.ProductsSupply.Where(x => x.WorkerInWorkPlace.Worker.Code == sCodeWorker).OrderByDescending(x => x.PeriodDate).ToList();
        }

        public IProductSupply Get(int idWorkerInWorkPlace, int idProduct, DateTime PeriodStartDate)
        {
            return Context.ProductsSupply.FirstOrDefault(p => p.IdProduct == idProduct &&
                                                             p.IdWorkerInWorkPlace == idWorkerInWorkPlace &&
                                                             p.PeriodDate == PeriodStartDate);

        }

        public IList<IProductSupplied> GetProductSuppliedToWorker(string sCodeProduct, string sCodeWorker, string sCodWorkPlace, DateTime date)
        {
            return Context.ProductsSupplied.Where(p => p.ParentProductSupplied== null &&
                                                       p.ProductStock.Product.Code == sCodeProduct &&
                                                       p.ProductSupply.WorkerInWorkPlace.Worker.Code == sCodeWorker &&
                                                       p.ProductSupply.WorkerInWorkPlace.WorkPlace.Code == sCodWorkPlace &&
                                                       p.ProductSupply.WorkerInWorkPlace.DateStart == date).ToList();
        }
    }
}
