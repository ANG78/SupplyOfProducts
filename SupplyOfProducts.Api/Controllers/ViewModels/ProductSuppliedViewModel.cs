using System;
using System.Collections.Generic;

namespace SupplyOfProducts.Api.Controllers.ViewModels
{

    public class ProductSuppliedViewModel
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string Type { get; set; }
        public string PartNumber { get; set; }
        public IList<ProductSuppliedViewModel> Parts { get; set; }
    }
}