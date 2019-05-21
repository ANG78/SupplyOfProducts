using System.Collections.Generic;

namespace SupplyOfProducts.Api.Controllers.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string Class { get; set; }

        public IList<ProductViewModel> Parts { get; set; }
    }
}
