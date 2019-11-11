using System.Collections.Generic;

namespace SupplyOfProducts.Api.Controllers.ViewModels
{
    public class ResponseSupplyByWorkPlaceViewModel
    { 
        public string CodeWorkPlace { get; set; }
        public IList<ProductSuppliedViewModel> ProductSupplied { get; set; } = new List<ProductSuppliedViewModel>();
    }
}
