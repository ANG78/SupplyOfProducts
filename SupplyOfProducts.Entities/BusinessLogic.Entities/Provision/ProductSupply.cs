using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using System;
using System.Collections.Generic;

namespace SupplyOfProducts.Entities.BusinessLogic.Entities.Provision
{

    public class ProductSupply : IProductSupplyRequest
    {
        public int Id { get; set; }
        public int WorkerInWorkPlaceId { get; set; }
        public int ProductId { get; set; }
        public IProduct Product { get; set; }
        public DateTime Date { get; set; }
        public DateTime PeriodDate { get; set; }  
        public IWorkerInWorkPlace WorkerInWorkPlace { get ; set ; }

        public IList<IProductSupplied> ProductsSupplied { get; set; } = new List<IProductSupplied>();
    }

}
