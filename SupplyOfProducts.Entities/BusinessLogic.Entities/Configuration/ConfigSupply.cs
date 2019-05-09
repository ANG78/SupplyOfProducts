using System;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;

namespace SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration
{


    public class ConfigSupply : IConfigSupplyRequest
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime PeriodDate { get; set; }
        public int WorkerInWorkPlaceId { get; set; }
        public IWorkerInWorkPlace WorkerInWorkPlace { get; set; }
        public int ProductId { get; set; }
        public IProduct Product { get; set; }
        public int Amount { get; set; }
        public ISupplyScheduled SupplyScheduled { get; set; }
        public int SupplyScheduledId { get; set; }
    }
}
