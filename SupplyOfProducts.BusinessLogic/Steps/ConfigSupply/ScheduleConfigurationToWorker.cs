
using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Provision;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;

namespace SupplyOfProducts.BusinessLogic.Steps.ConfigSupply
{

    public class ScheduleConfigurationToWorker : StepDecoratorTemplateGeneric<IManagementModelRequest<IConfigSupply>>
    {
        readonly ISupplyScheduledService _supplyScheduledService;

        public ScheduleConfigurationToWorker(ISupplyScheduledService supplyScheduledService) : base(null)
        {
            _supplyScheduledService = supplyScheduledService;

        }

        public override string Description()
        {
            return "Assignation of one Product in Stock when processing a Product Supply Request";
        }

        protected override IResult ExecuteTemplate(IManagementModelRequest<IConfigSupply> obj)
        {
            if (obj.Item.SupplyScheduled != null && obj.Item.SupplyScheduled.Id > 0)
            {
                obj.Item.SupplyScheduled.Amount = obj.Item.Amount;
            }
            else
            {
                obj.Item.SupplyScheduled = new SupplyScheduled
                {
                    Product = obj.Item.Product,
                    PeriodDate = obj.Item.PeriodDate,
                    WorkerInWorkPlace = obj.Item.WorkerInWorkPlace,
                    Amount = obj.Item.Amount
                };
            }

            obj.Item.SupplyScheduled.ConfiguratedBy.Add(obj.Item);
            _supplyScheduledService.Save(obj.Item.SupplyScheduled);

            return Result.Ok;
        }
    }
}
