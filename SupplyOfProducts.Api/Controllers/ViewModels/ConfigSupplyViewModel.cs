using Newtonsoft.Json;
using System;

namespace SupplyOfProducts.Api.Controllers.ViewModels
{

    public class ConfigSupplyViewModel
    {
        [JsonProperty(Required = Required.Always)]
        public string WorkerCode { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string ProductCode { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string WorkPlaceCode { get; set; }
        public DateTime? Date { get; set; }
        [JsonProperty(Required = Required.Always)]
        public int Amount { get; set; }
    }

    public class ConfigSupplyViewModelExt : ConfigSupplyViewModel
    {
        public DateTime? PeriodDate { get; set; }

        public int AmountSupplied { get; set; }
    }

    
}