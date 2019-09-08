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

   

}
