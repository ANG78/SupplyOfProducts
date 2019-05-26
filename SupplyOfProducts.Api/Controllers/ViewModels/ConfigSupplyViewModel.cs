using System;

namespace SupplyOfProducts.Api.Controllers.ViewModels
{

    public class ConfigSupplyViewModel
    {
        public string WorkerCode { get; set; }
        public string ProductCode { get; set; }
        public string WorkPlaceCode { get; set; }
        public DateTime? Date { get; set; }
        public int Amount { get; set; }

    }

    public class ConfigSupplyViewModelExt : ConfigSupplyViewModel
    {
        public DateTime? PeriodDate { get; set; }
        public int AmountSupplied { get; set; }
    }
}