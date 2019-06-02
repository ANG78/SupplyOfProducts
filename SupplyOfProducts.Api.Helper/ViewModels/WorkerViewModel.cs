using Newtonsoft.Json;

namespace SupplyOfProducts.Api.Controllers.ViewModels
{
    public class WorkerViewModel
    {
        public int Id { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string Code { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string Name { get; set; }   
    }
}
