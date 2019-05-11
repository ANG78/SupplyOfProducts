
using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Provision;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;

namespace SupplyOfProducts.BusinessLogic.Steps.ConfigSupply
{

    public class ScheduleConfigurationToWorker : StepDecoratorTemplateGeneric<IConfigSupplyRequest>
    {
        readonly ISupplyScheduledService _supplyScheduledService;

        public ScheduleConfigurationToWorker(ISupplyScheduledService supplyScheduledService,
                                             IStep<IConfigSupplyRequest> next = null) : base(next)
        {
            _supplyScheduledService = supplyScheduledService;

        }

        public override string Description()
        {
            return "Assignation of one Product in Stock when processing a Product Supply Request";
        }

        protected override IResult ExecuteTemplate(IConfigSupplyRequest obj)
        {
            if (obj.SupplyScheduled != null && obj.SupplyScheduled.Id > 0)
            {
                obj.SupplyScheduled.Amount = obj.Amount;
            }
            else
            {
                obj.SupplyScheduled = new SupplyScheduled
                {
                    Product = obj.Product,
                    PeriodDate = obj.PeriodDate,
                    WorkerInWorkPlace = obj.WorkerInWorkPlace,
                    Amount = obj.Amount
                };
            }

            obj.SupplyScheduled.ConfiguratedBy.Add(obj);
            _supplyScheduledService.Save(obj.SupplyScheduled);

            return Result.Ok;
        }
    }
}
