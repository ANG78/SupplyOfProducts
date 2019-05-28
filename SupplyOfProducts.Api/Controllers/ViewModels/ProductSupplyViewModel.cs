using System;
using System.Collections.Generic;

namespace SupplyOfProducts.Api.Controllers.ViewModels
{
    public class ProductSupplyViewModel
    {
        public string WorkerCode { get; set; }
        public string ProductCode { get; set; }
        public string WorkPlaceCode { get; set; }
        public DateTime? Date { get; set; }
    }

    public class ProductSupplyViewModelExt
    {
        public string WorkerCode { get; set; }
        public string ProductCode { get; set; }
        public string WorkPlaceCode { get; set; }
        public DateTime PeriodDate { get; set; }
        public DateTime Date { get; set; }
        public IList<ProductSuppliedViewModel> ProductsSupplied { get;set;}
    }
}