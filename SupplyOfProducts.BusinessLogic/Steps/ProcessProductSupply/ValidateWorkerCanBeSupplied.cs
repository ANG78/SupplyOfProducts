using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;

namespace SupplyOfProducts.BusinessLogic.Steps.ProcessProductSupply
{
    public class ValidateWorkerCanBeSupplied : StepDecoratorTemplateGeneric<IProductSupply>
    {
        readonly IProductSupplyService _productSupplyService;
        readonly ISupplyScheduledService _supplyScheduledService;

        public ValidateWorkerCanBeSupplied(IProductSupplyService productSupplyService,
                                     ISupplyScheduledService supplyScheduledService,
                                     IStep<IProductSupply> next = null) : base(next)
        {
            _productSupplyService = productSupplyService;
            _supplyScheduledService = supplyScheduledService;
        }

        public override string Description()
        {
            return "Check that the Worker can be supplied the product involved in the request taking into account its Supply Setting and the products already supplied in the period";
        }

        protected override IResult ExecuteTemplate(IProductSupply obj)
        {
            var supplyScheduled = _supplyScheduledService.Get(obj.Product.Code, obj.WorkerInWorkPlace.Worker.Code, obj.WorkerInWorkPlace.WorkPlace.Code, obj.PeriodDate);
            if (supplyScheduled == null)
            {
                return new Result(EnumResultBL.ERROR_WORKER_NOT_FOUND_A_SUPPLY_SCHEDULED_OF_THE_PRODUCT_FOR_THE_WORKER_AND_WORKPLACE_IN_THE_DATE, obj.WorkerInWorkPlace.Worker.Code, obj.Product.Code, obj.WorkerInWorkPlace.WorkPlace.Code, obj.PeriodDate);
            }

            var productsReceived = _productSupplyService.GetProductSuppliedToWorker(obj.Product.Code, obj.WorkerInWorkPlace.Worker.Code, obj.WorkerInWorkPlace.WorkPlace.Code, obj.PeriodDate);
            if (productsReceived.Count >= supplyScheduled.Amount)
            {
                return new Result(EnumResultBL.ERROR_WORKER_HAS_REACHED_THE_LIMIT_OF_PRODUCTS_OF_THIS_TYPE, obj.WorkerInWorkPlace.Worker.Code, supplyScheduled.Amount, obj.Product.Code, obj.WorkerInWorkPlace.WorkPlace.Code, obj.PeriodDate);
            }

            return Result.Ok;
        }
    }
    
}