using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using System.Collections.Generic;


namespace SupplyOfProducts.BusinessLogic.Steps
{
    public class RetrieverByWorkerGeneric<TModel, TService> :
      StepDecoratorTemplateGeneric<IManagementModelRetrieverRequest<TModel>>
      where TService : IGenericNotSingleCodeReadService<TModel>
    {
        TService _Service;

        public RetrieverByWorkerGeneric(TService pService)
        {
            _Service = pService;
        }

        public override string Description()
        {
            return "Retriever";
        }

        protected override IResult ExecuteTemplate(IManagementModelRetrieverRequest<TModel> obj)
        {
            if (string.IsNullOrWhiteSpace(obj?.Code))
            {
                obj.Items = _Service.GetAll();
            }
            else
            {
                obj.Items = _Service.Get(obj.Code);
            }


            return Result.Ok;
        }
    }
}
