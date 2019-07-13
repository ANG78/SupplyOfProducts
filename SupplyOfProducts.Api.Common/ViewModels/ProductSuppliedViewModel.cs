using Newtonsoft.Json;

namespace SupplyOfProducts.Api.Controllers.ViewModels
{

    public class ProductSuppliedViewModel
    {
        [JsonProperty(Required = Required.Always)]
        public int Id { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string ProductCode { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string Type { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string PartNumber { get; set; }

    }
}