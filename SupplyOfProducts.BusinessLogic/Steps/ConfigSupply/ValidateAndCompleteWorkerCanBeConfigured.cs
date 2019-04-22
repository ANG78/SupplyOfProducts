using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;

namespace SupplyOfProducts.BusinessLogic.Steps.ConfigSupply
{
    public class ValidateAndCompleteWorkerCanBeConfigured : StepDecoratorTemplateGeneric<IConfigSupply>
    {
        readonly IProductSupplyService _productSupplyService;
        readonly ISupplyScheduledService _supplyScheduledService;

        public ValidateAndCompleteWorkerCanBeConfigured(IProductSupplyService productSupplyService,
                                                        ISupplyScheduledService supplyScheduledService,
                                                        IStep<IConfigSupply> next = null) : base(next)
        {
            _productSupplyService = productSupplyService;
            _supplyScheduledService = supplyScheduledService;
        }

        public override string Description()
        {
            return "Check that the Worker can be configured with the request data.";
        }

        protected override IResult ExecuteTemplate(IConfigSupply obj)
        {
            var supplyScheduled = _supplyScheduledService.Get(obj.Product.Code, obj.WorkerInWorkPlace.Worker.Code, obj.WorkerInWorkPlace.WorkPlace.Code, obj.PeriodDate);
            if (supplyScheduled != null && supplyScheduled.Amount == obj.Amount)
            {
                obj.Result = supplyScheduled;
                return OkAndFinish("The Configuration is the same as the one already registered in the system");
            }

            var productsReceived = _productSupplyService.GetProductSuppliedToWorker(obj.WorkerInWorkPlace.Worker.Code);
            if (productsReceived.Count >= obj.Amount)
            {
                return new Result(EnumResultBL.ERROR_THE_NEW_AMOUNT_MEANT_TO_BE_SET_IS_SMALLER_THAN_THE_ONE_ALREADY_SUPPLIED, obj.WorkerInWorkPlace.Worker.Code, supplyScheduled.Amount, obj.Product.Code, obj.WorkerInWorkPlace.WorkPlace.Code, obj.PeriodDate);
            }

            obj.Result = supplyScheduled;

            return Result.Ok;
        }
    }
}
