using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System;
using System.Collections.Generic;

namespace SupplyOfProducts.Entities.BusinessLogic.Entities.Provision
{
    public partial class SupplyScheduled : ISupplyScheduled
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int WorkerInWorkPlaceId { get; set; }

        public DateTime PeriodDate { get; set; }
        public int Amount { get; set; }

        public IWorkerInWorkPlace WorkerInWorkPlace { get; set; }
        public IProduct Product { get; set; }

        public IList<IConfigSupply> ConfiguratedBy { get; set; } = new List<IConfigSupply>();
        
    }
}
