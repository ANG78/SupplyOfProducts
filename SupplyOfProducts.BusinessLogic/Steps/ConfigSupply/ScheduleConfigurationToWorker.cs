
using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Provision;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;


namespace SupplyOfProducts.BusinessLogic.Steps.ConfigSupply
{

    public class ScheduleConfigurationToWorker : StepDecoratorTemplateGeneric<IConfigSupply>
    {
        readonly ISupplyScheduledService _supplyScheduledService;

        public ScheduleConfigurationToWorker(ISupplyScheduledService supplyScheduledService,
                                             IStep<IConfigSupply> next = null) : base(next)
        {
            _supplyScheduledService = supplyScheduledService;

        }

        public override string Description()
        {
            return "Assignation of one Product in Stock when processing a Product Supply Request";
        }

        protected override IResult ExecuteTemplate(IConfigSupply obj)
        {
            if (obj.Result != null && obj.Result.Id > 0)
            {
                obj.Result.Amount = obj.Amount;
            }
            else
            {
                obj.Result = new SupplyScheduled
                {
                    Product = obj.Product,
                    PeriodDate = obj.PeriodDate,
                    WorkerInWorkPlace = obj.WorkerInWorkPlace,
                    Amount = obj.Amount
                };
            }

            _supplyScheduledService.Save(obj.Result);

            return Result.Ok;
        }
    }
}
