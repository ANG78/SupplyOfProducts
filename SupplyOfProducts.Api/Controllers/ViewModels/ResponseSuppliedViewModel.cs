using System;
using System.Collections.Generic;

namespace SupplyOfProducts.Api.Controllers.ViewModels
{
    public class ResponseSuppliedViewModel : IResponseViewModel
    {
        public ResponseViewModel Status { get; set; } = new ResponseViewModel();
        public ResponseSupplyViewModel Request { get; set; }
    }   
    
    public class ResponseSupplyViewModel
    {
        public string CodeWorker { get; set; }
        public string CodeWorkPlace { get; set; }
        public DateTime? Period { get; set; }
        public ProductSuppliedViewModel ProductSupplied { get; set; }
    }

    public class ProductSuppliedViewModel
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string Type { get; set; }
        public string PartNumber { get; set; }
        public List<ProductSuppliedViewModel> Parts { get; set; }
    }

}
