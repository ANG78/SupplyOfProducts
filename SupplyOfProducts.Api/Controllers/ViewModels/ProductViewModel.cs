using Newtonsoft.Json;
using System.Collections.Generic;

namespace SupplyOfProducts.Api.Controllers.ViewModels
{
    public class ProductViewModel
    {
        [JsonProperty(Required = Required.Always)]
        public int Id { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string Code { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string Type { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string Class { get; set; }
    }

    public class ProductComplexViewModel : ProductViewModel
    {
        public IList<ProductViewModel> Parts { get; set; }
    }
}
