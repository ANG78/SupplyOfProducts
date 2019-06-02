using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using System.Linq;

namespace SupplyOfProducts.BusinessLogic.Steps.ConfigSupply
{
    public class ValidateAndCompleteWorkerCanBeConfigured : StepDecoratorTemplateGeneric< IManagementModelRequest<IConfigSupply> >
    {
        readonly IProductSupplyService _productSupplyService;
        readonly ISupplyScheduledService _supplyScheduledService;

        public ValidateAndCompleteWorkerCanBeConfigured(IProductSupplyService productSupplyService,
                                                        ISupplyScheduledService supplyScheduledService) : base(null)
        {
            _productSupplyService = productSupplyService;
            _supplyScheduledService = supplyScheduledService;
        }

        public override string Description()
        {
            return "Check that the Worker can be configured with the request data.";
        }

        protected override IResult ExecuteTemplate(IManagementModelRequest<IConfigSupply> obj)
        {
            IConfigSupply itemRequest = obj.Item;
            var supplyScheduled = _supplyScheduledService.Get(itemRequest.Product.Code,
                                                              itemRequest.WorkerInWorkPlace.Worker.Code,
                                                              itemRequest.WorkerInWorkPlace.WorkPlace.Code,
                                                              itemRequest.PeriodDate);

            if (supplyScheduled != null ) 
            {

                if (supplyScheduled.Amount == obj.Item.Amount)
                {
                    obj.Item.SupplyScheduled = supplyScheduled;
                    return OkAndFinish("The Configuration is the same as the one already registered in the system");
                }

                var productsReceived = _productSupplyService.GetProductSuppliedToWorker(itemRequest.Product.Code,
                                                                                        itemRequest.WorkerInWorkPlace.Worker.Code,
                                                                                        itemRequest.WorkerInWorkPlace.WorkPlace.Code,
                                                                                        itemRequest.PeriodDate);
                if (productsReceived.Count() >= obj.Item.Amount)
                {
                    return new Result(EnumResultBL.ERROR_THE_NEW_AMOUNT_MEANT_TO_BE_SET_IS_SMALLER_THAN_THE_ONE_ALREADY_SUPPLIED,
                                        itemRequest.WorkerInWorkPlace.Worker.Code,
                                        supplyScheduled.Amount, obj.Item.Product.Code,
                                        itemRequest.WorkerInWorkPlace.WorkPlace.Code,
                                        itemRequest.PeriodDate);
                }
            }

            itemRequest.SupplyScheduled = supplyScheduled;

            return Result.Ok;
        }
    }



}
