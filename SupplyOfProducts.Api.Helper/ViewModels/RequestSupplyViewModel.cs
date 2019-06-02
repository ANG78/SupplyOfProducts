using Newtonsoft.Json;
using System;

namespace SupplyOfProducts.Api.Controllers.ViewModels
{
    public class RequestSupplyViewModel 
    {
        [JsonProperty(Required = Required.Always)]
        public string WorkerCode { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string ProductCode { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string WorkPlaceCode { get; set; }
        public DateTime? Date { get; set; }
    }

   
}
