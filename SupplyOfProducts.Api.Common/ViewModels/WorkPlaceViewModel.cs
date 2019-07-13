using Newtonsoft.Json;

namespace SupplyOfProducts.Api.Controllers.ViewModels
{
    public class WorkPlaceViewModel
    {
        public int Id { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string Code { get; set; }
    }
}
