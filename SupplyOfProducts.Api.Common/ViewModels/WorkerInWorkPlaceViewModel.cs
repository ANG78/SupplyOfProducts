using Newtonsoft.Json;
using System;

namespace SupplyOfProducts.Api.Controllers.ViewModels
{
    public class WorkerInWorkPlaceViewModel {
        public int Id { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string WorkerCode { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string WorkPlaceCode { get; set; }

        [JsonProperty(Required = Required.Always)]
        public DateTime DateStart { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int NumYearsByPeriod { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public DateTime? DateEnd { get; set; }
    }
}
