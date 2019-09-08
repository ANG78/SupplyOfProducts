using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using System.Linq;

namespace SupplyOfProducts.BusinessLogic.Steps.ProcessProductSupply
{
    public class ValidateWorkerCanBeSupplied : StepTemplateGeneric< IManagementModelRequest<IProductSupply > >
    {
        readonly IProductSupplyService _productSupplyService;
        readonly ISupplyScheduledService _supplyScheduledService;

        public ValidateWorkerCanBeSupplied(IProductSupplyService productSupplyService,
                                     ISupplyScheduledService supplyScheduledService,
                                     IStep< IManagementModelRequest<IProductSupply> > next = null) : base(next)
        {
            _productSupplyService = productSupplyService;
            _supplyScheduledService = supplyScheduledService;
        }

        public override string Description()
        {
            return "Check that the Worker can be supplied the product involved in the request taking into account its Supply Setting and the products already supplied in the period";
        }

        protected override IResult ExecuteTemplate(IManagementModelRequest<IProductSupply> obj)
        {
            IProductSupply itemRequest = obj.Item;
            var supplyScheduled = _supplyScheduledService.Get(itemRequest.Product.Code, 
                                                              itemRequest.WorkerInWorkPlace.Worker.Code, 
                                                              itemRequest.WorkerInWorkPlace.WorkPlace.Code, 
                                                              itemRequest.PeriodDate);
            if (supplyScheduled == null)
            {
                return new Result(EnumResultBL.ERROR_WORKER_NOT_FOUND_A_SUPPLY_SCHEDULED_OF_THE_PRODUCT_FOR_THE_WORKER_AND_WORKPLACE_IN_THE_DATE, itemRequest.WorkerInWorkPlace.Worker.Code, itemRequest.Product.Code, itemRequest.WorkerInWorkPlace.WorkPlace.Code, itemRequest.PeriodDate);
            }

            var productsReceived = _productSupplyService.GetProductSuppliedToWorker(itemRequest.Product.Code,
                                                                                    itemRequest.WorkerInWorkPlace.Worker.Code,
                                                                                    itemRequest.WorkerInWorkPlace.WorkPlace.Code,
                                                                                    itemRequest.PeriodDate);
            if (productsReceived.ToList().Count >= supplyScheduled.Amount)
            {
                return new Result(EnumResultBL.ERROR_WORKER_HAS_REACHED_THE_LIMIT_OF_PRODUCTS_OF_THIS_TYPE, itemRequest.WorkerInWorkPlace.Worker.Code, supplyScheduled.Amount, itemRequest.Product.Code, itemRequest.WorkerInWorkPlace.WorkPlace.Code, itemRequest.PeriodDate);
            }

            return Result.Ok;
        }
    }
    
}