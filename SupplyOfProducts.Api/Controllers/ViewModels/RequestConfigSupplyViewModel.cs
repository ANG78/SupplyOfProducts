using System;

namespace SupplyOfProducts.Api.Controllers.ViewModels
{

    public class RequestConfigSupplyViewModel
    {
        public string CodeWorker { get; set; }
        public string CodeProduct { get; set; }
        public string CodeWorkPlace { get; set; }
        public DateTime? Date { get; set; }
        public int Amount { get; set; }

    }

}
