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
            return Context.ProductsSupply.FirstOrDefault(p => p.WorkerInWorkPlaceId == id);
        }

        public void Save(IProductSupply obj)
        {
            if (obj.Id == 0)
            {
                obj.Id = MemoryContext.IdInternal;
                Context.ProductsSupply.Add(obj);
            }

            /*
            if (obj.ProductSupplied != null)
            {
                if (obj.ProductSupplied.Id == 0)
                {
                    obj.ProductSupplied.Id = MemoryContext.IdInternal;
                    Context.ProductsSupplied.Add(obj.ProductSupplied);
                }

                obj.ProductSupplied.ProductSupplyId = obj.WorkerInWorkPlaceId;
                obj.ProductSupplied.ProductStockId = obj.ProductSupplied.ProductStock.Id;
                obj.ProductSuppliedId = obj.ProductSupplied.Id;
            }
            */
        }

        public void Remove(IProductSupply obj)
        {
            if (obj.Id > 0)
            {
                Context.ProductsSupply.Remove(obj);
            }

            if (obj.ProductsSupplied != null && obj.ProductsSupplied.Count > 0)
            {
                foreach (var x in obj.ProductsSupplied)
                {
                    var ind = Context.ProductsSupplied.IndexOf(x);
                    if (ind >= 0)
                    {
                        Context.ProductsSupplied.RemoveAt(ind);
                    }
                     
                }

                obj.ProductsSupplied.Clear();
            }
        }

        public void Save(IProductSupplied obj)
        {
            obj.Id = MemoryContext.IdInternal;
            Context.ProductsSupplied.Add(obj);
        }
               

        public IList<IProductSupply> GetProductSuppliedToWorker(string sCodeWorker)
        {
            return Context.ProductsSupply.Where(x => x.WorkerInWorkPlace.Worker.Code == sCodeWorker).OrderByDescending(x => x.PeriodDate).ToList();
        }

        public IProductSupply Get(int idWorkerInWorkPlace, int idProduct, DateTime PeriodStartDate)
        {
            return Context.ProductsSupply.FirstOrDefault(p => p.ProductId == idProduct &&
                                                             p.WorkerInWorkPlaceId == idWorkerInWorkPlace &&
                                                             p.PeriodDate == PeriodStartDate);

        }

        public IList<IProductSupplied> GetProductSuppliedToWorkerOnThisPeriod(string sCodeProduct, string sCodeWorker, string sCodWorkPlace, DateTime date)
        {
            return Context.ProductsSupplied.Where(p => p.ProductStock.Product.Code == sCodeProduct &&
                                                       p.ProductSupply.WorkerInWorkPlace.Worker.Code == sCodeWorker &&
                                                       p.ProductSupply.WorkerInWorkPlace.WorkPlace.Code == sCodWorkPlace &&
                                                       p.ProductSupply.WorkerInWorkPlace.DateStart == date).ToList();
        }

        public IEnumerable<IProductSupply> GetAll(string WorkerCode)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProductSupply> GetAll(int idWorkerInWorkPlace, int idProduct, DateTime PeriodStartDate)
        {
            throw new NotImplementedException();
        }

        IEnumerable<IProductSupplied> IProductSupplyRepository.GetProductSuppliedToWorkerOnThisPeriod(string sProduct, string sCodeWorker, string sCodWorkPlace, DateTime date)
        {
            throw new NotImplementedException();
        }

        public IProductSupply Get(string code)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProductSupply> Get()
        {
            throw new NotImplementedException();
        }

        public void Edit(IProductSupply worker)
        {
            throw new NotImplementedException();
        }

        public void Add(IProductSupply worker)
        {
            throw new NotImplementedException();
        }

        IEnumerable<IProductSupply> IGenericNotSingleCodeReadRepository<IProductSupply>.Get(string code)
        {
            throw new NotImplementedException();
        }
    }
}
