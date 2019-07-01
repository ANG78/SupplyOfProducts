using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using System.Collections.Generic;

namespace SupplyOfProducts.BusinessLogic.Steps
{
    public class RetrieverGeneric<TModel, TService> :
        StepDecoratorTemplateGeneric<IManagementModelRetrieverRequest<TModel>>
        where TService : IGenericService<TModel>
    {
        TService _Service;

        public RetrieverGeneric(TService pService)
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

                var objectAux = _Service.Get(obj.Code);


                if (objectAux != null)
                {
                    obj.Items = new List<TModel>
                    {
                        objectAux

                    };

                }
                else
                {
                    obj.Items = new List<TModel>();
                }

            }


            return Result.Ok;
        }
    }


   
}
