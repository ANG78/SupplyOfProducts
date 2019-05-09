using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupplyOfProducts.Api.Controllers.ViewModels
{
    public class ResponseConfigViewModel : IResponseViewModel
    {
        public ResponseViewModel Status { get; set; } = new ResponseViewModel();
        public ResponseConfigRequestViewModel Request { get; set; }
    }

    public class ResponseConfigRequestViewModel
    {
        public string CodeWorker { get; set; }
        public string CodeWorkPlace { get; set; }
        public DateTime? Period { get; set; }
        public int Amount {get;set;}
    }
}
