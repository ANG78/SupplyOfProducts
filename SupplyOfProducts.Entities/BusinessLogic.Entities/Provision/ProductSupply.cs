using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System;

namespace SupplyOfProducts.Entities.BusinessLogic.Entities.Provision
{

    public class ProductSupply : IProductSupply
    {
        public int Id { get; set; }
        public int IdWorkerInWorkPlace { get; set; }
        public int IdProduct { get; set; }
        public int IdProductSupplied { get; set; }
        public IProduct Product { get; set; }
        public DateTime Date { get; set; }
        public DateTime PeriodDate { get; set; }
        public IProductSupplied ProductSupplied { get; set; }
        public IWorkerInWorkPlace WorkerInWorkPlace { get ; set ; }
    }

}
