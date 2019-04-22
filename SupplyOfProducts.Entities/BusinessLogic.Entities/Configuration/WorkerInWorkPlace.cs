using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System;

namespace SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration
{
    public class WorkerInWorkPlace : IWorkerInWorkPlace
    {
        public int Id { get; set; }
        public int IdWorker { get; set; }
        public int IdWorkPlace { get; set; }
        public DateTime DateStart { get; set; }
        public uint NumYearsByPeriod { get; set; }
        public DateTime? DateFinish { get; set; }
        public IWorker Worker { get; set; }
        public IWorkPlace WorkPlace { get; set; }
    }
}
