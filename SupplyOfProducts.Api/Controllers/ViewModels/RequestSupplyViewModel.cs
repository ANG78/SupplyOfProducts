using System;

namespace SupplyOfProducts.Api.Controllers.ViewModels
{
    public class RequestSupplyViewModel 
    {
        public string WorkerCode { get; set; }
        public string ProductCode { get; set; }
        public string WorkPlaceCode { get; set; }
        public DateTime? Date { get; set; }
    }

   
}
