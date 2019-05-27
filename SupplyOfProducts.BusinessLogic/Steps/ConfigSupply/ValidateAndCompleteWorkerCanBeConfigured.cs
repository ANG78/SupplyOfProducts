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
            var supplyScheduled = _supplyScheduledService.Get(obj.Item.Product.Code, 
                                                              obj.Item.WorkerInWorkPlace.Worker.Code, 
                                                              obj.Item.WorkerInWorkPlace.WorkPlace.Code, 
                                                              obj.Item.PeriodDate);
            if (supplyScheduled != null && supplyScheduled.Amount == obj.Item.Amount)
            {
                obj.Item.SupplyScheduled = supplyScheduled;
                return OkAndFinish("The Configuration is the same as the one already registered in the system");
            }

            var productsReceived = _productSupplyService.GetAll(obj.Item.WorkerInWorkPlace.Worker.Code);
            if (productsReceived.Count() >= obj.Item.Amount)
            {
                return new Result(EnumResultBL.ERROR_THE_NEW_AMOUNT_MEANT_TO_BE_SET_IS_SMALLER_THAN_THE_ONE_ALREADY_SUPPLIED, 
                                    obj.Item.WorkerInWorkPlace.Worker.Code, 
                                    supplyScheduled.Amount, obj.Item.Product.Code, 
                                    obj.Item.WorkerInWorkPlace.WorkPlace.Code, 
                                    obj.Item.PeriodDate);
            }

            obj.Item.SupplyScheduled = supplyScheduled;

            return Result.Ok;
        }
    }



}
