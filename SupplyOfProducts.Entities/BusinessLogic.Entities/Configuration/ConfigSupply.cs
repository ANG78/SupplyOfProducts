using System;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration
{
   

    public class ConfigSupply : IConfigSupply
    {
        public int Id { get; set; }
        public DateTime Date { get ; set ; }
        public DateTime PeriodDate { get ; set ; }
        public int IdWorkerInWorkPlace { get ; set ; }
        public IWorkerInWorkPlace WorkerInWorkPlace { get ; set ; }
        public int IdProduct { get ; set ; }
        public IProduct Product { get ; set ; }
        public ISupplyScheduled Result { get ; set ; }
        public uint Amount { get ; set ; }
    }
}
