using System;

namespace SupplyOfProducts.Api.Controllers.ViewModels
{
    public class RequestSupplyViewModel 
    {
        public string CodeWorker { get; set; }
        public string CodeProduct { get; set; }
        public string CodeWorkPlace { get; set; }
        public DateTime? Date { get; set; }
    }

   
}
