using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Provision;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Store;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SupplyOfProducts.Persistance
{
    public class MemoryContext
    {
        static readonly object ReferenciaLock = new object();
        static int idObj = 1;
        public static int IdInternal
        {
            get
            {
                lock (ReferenciaLock)
                {
                    idObj = idObj + 1;
                    return idObj;
                }
            }
        }

        public List<IProduct> Products;
        public List<IWorker> Workers;
        public List<IWorkPlace> WorkPlaces;
        public List<IWorkerInWorkPlace> WorkerWorkPlaces = new List<IWorkerInWorkPlace>();
        public List<IProductSupply> ProductsSupply = new List<IProductSupply>();
        public List<IProductSupplied> ProductsSupplied = new List<IProductSupplied>();
        public List<IProductStock> ProductsStock;
        public List<ISupplyScheduled> SuppliesScheduled;

        public MemoryContext()
        {
            LoadDataConfiguration();
        }

        private T Get<T>(string code, List<T> listObjects) where T : ICode
        {
            return listObjects.FirstOrDefault(x => x.Code == code);
        }




        public void LoadDataConfiguration()
        {
            Products = new List<IProduct>();
            Workers = new List<IWorker> ();
            WorkPlaces = new List<IWorkPlace> ();
            WorkerWorkPlaces = new List<IWorkerInWorkPlace>();
            ProductsSupply = new List<IProductSupply>();
            ProductsSupplied = new List<IProductSupplied>();
            ProductsStock = new List<IProductStock> ();
            SuppliesScheduled = new List<ISupplyScheduled>();


            string sW01 = "W01";
            string sW02 = "W02";
            string sW03 = "W03";

            string sWP01 = "WP01";
            string sWP02 = "WP02";

            string sP01 = "EPI1";
            string sP02 = "EPI2";
            string sP03 = "EPI3";
            string sP04 = "EPI4";
            string sP05 = "EPI5";


            Products = new List<IProduct>
            {
                new Product { Id = IdInternal, Code = sP01, Type = "Helmet" },
                new Product { Id = IdInternal, Code = sP02, Type = "Boots" },
                new Product { Id = IdInternal, Code = sP03, Type = "Glasses" },
                new Product { Id = IdInternal, Code = sP04, Type = "Gloves" },

            };

            Products.Add(new PackageProduct
            {
                Id = IdInternal,
                Code = sP05,
                Type = "Kit1",               
            });

            Products.Add(Get(sP01, Products));
            Products.Add(Get(sP02, Products));
            

            Workers = new List<IWorker>
            {
                new Worker
                {
                    Id = IdInternal, Code = sW01, Name = "User1"
                },
                new Worker
                {
                    Id = IdInternal, Code = sW02, Name = "User2"
                },
                new Worker
                {
                    Id = IdInternal, Code = sW03, Name = "User3"
                }
            };

            WorkPlaces = new List<IWorkPlace>
            {
                new WorkPlace { Id = IdInternal, Code = sWP01 },
                new WorkPlace { Id = IdInternal, Code = sWP02 }
            };

            ProductsStock = new List<IProductStock>();
            foreach (var it in Products)
            {
                for (uint i = 1; i <= 5; i++)
                {
                    ProductsStock.Add(new ProductStock() { Id = IdInternal, Product = it, Code = it.Code + "-0" + i });
                }
            }

            WorkerWorkPlaces.Add(new WorkerInWorkPlace { Id = IdInternal, Worker = Get(sW01, Workers), WorkerId = Get(sW01, Workers).Id, WorkPlace = Get(sWP01, WorkPlaces), WorkPlaceId = Get(sWP01, WorkPlaces).Id, DateStart = new DateTime(2010, 1, 1), NumYearsByPeriod = 3, DateEnd = new DateTime(2015, 1, 1) });
            WorkerWorkPlaces.Add(new WorkerInWorkPlace { Id = IdInternal, Worker = Get(sW01, Workers), WorkerId = Get(sW01, Workers).Id, WorkPlace = Get(sWP02, WorkPlaces), WorkPlaceId = Get(sWP02, WorkPlaces).Id, DateStart = new DateTime(2012, 1, 1), NumYearsByPeriod = 2 });
            WorkerWorkPlaces.Add(new WorkerInWorkPlace { Id = IdInternal, Worker = Get(sW02, Workers), WorkerId = Get(sW02, Workers).Id, WorkPlace = Get(sWP01, WorkPlaces), WorkPlaceId = Get(sWP01, WorkPlaces).Id, DateStart = new DateTime(2010, 1, 1), NumYearsByPeriod = 1 });

            SuppliesScheduled = new List<ISupplyScheduled>();
            foreach (var it in WorkerWorkPlaces)
            {
                for (uint i = 1; i <= 2; i++)
                {
                    SuppliesScheduled.Add(new SupplyScheduled() { Id = IdInternal, Amount = 1, Product = Get(sP05, Products), ProductId = Get(sP05, Products).Id, WorkerInWorkPlace = it, WorkerInWorkPlaceId = it.Id, PeriodDate = it.DateStart });
                    SuppliesScheduled.Add(new SupplyScheduled() { Id = IdInternal, Amount = 2, Product = Get(sP01, Products), ProductId = Get(sP01, Products).Id, WorkerInWorkPlace = it, WorkerInWorkPlaceId = it.Id, PeriodDate = it.DateStart });
                    SuppliesScheduled.Add(new SupplyScheduled() { Id = IdInternal, Amount = 1, Product = Get(sP02, Products), ProductId = Get(sP02, Products).Id, WorkerInWorkPlace = it, WorkerInWorkPlaceId = it.Id, PeriodDate = it.DateStart });
                    SuppliesScheduled.Add(new SupplyScheduled() { Id = IdInternal, Amount = 3, Product = Get(sP03, Products), ProductId = Get(sP03, Products).Id, WorkerInWorkPlace = it, WorkerInWorkPlaceId = it.Id, PeriodDate = it.DateStart });
                }
            }

            ProductsSupplied = new List<IProductSupplied>();
        }

    }



    public class BaseRepository
    {
        protected readonly MemoryContext Context;
        public BaseRepository(MemoryContext context)
        {
            Context = context;
        }
    }
}


