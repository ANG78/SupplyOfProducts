using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SupplyOfProducts.Api.Controllers.ViewModels
{
    public class ProductSupplyViewModel
    {
        [JsonProperty(Required = Required.Always)]
        public string WorkerCode { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string ProductCode { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string WorkPlaceCode { get; set; }

        public DateTime? Date { get; set; }
    }

    public class ProductSupplyViewModelExt
    {
        [JsonProperty(Required = Required.Always)]
        public string WorkerCode { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string ProductCode { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string WorkPlaceCode { get; set; }
        [JsonProperty(Required = Required.Always)]
        public DateTime PeriodDate { get; set; }
        [JsonProperty(Required = Required.Always)]
        public DateTime Date { get; set; }

        public IList<ProductSuppliedViewModel> ProductsSupplied { get;set;}
    }
}