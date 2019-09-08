using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System;

namespace SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration
{
    public partial class WorkerInWorkPlace : IWorkerInWorkPlace
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public int WorkPlaceId { get; set; }
        public DateTime DateStart { get; set; }
        public int NumYearsByPeriod { get; set; }
        public DateTime? DateEnd { get; set; }

        public IWorker Worker { get { return WorkerEF; } set { WorkerEF = (Worker)value;  } }
        public IWorkPlace WorkPlace { get { return WorkPlaceEF; } set { WorkPlaceEF = (WorkPlace)value; } }

        public WorkPlace WorkPlaceEF { get; set; }
        public Worker WorkerEF { get; set; }
        public WorkerInWorkPlace() { }

        public WorkerInWorkPlace(IWorker pWorker, IWorkPlace pWorkPlace) {
            Worker = pWorker;
            WorkPlace = pWorkPlace;

        }

    }
}
