using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;

namespace SupplyOfProducts.BusinessLogic.Steps.Common
{
    public class StepSaveModel<T> : StepDecoratorTemplateGeneric< IManagementModelRequest<T> >
    {
        readonly IGenericService<T> _service;

        public StepSaveModel(IGenericService<T> service) : base(null)
        {
            _service = service;
        }

        public override string Description()
        {
            return "Record Model in Repositories.";
        }

        protected override IResult ExecuteTemplate( IManagementModelRequest<T> obj)
        {
            if (obj.Type == TypeManagement.NEW)
            {
               return _service.Save(obj.Item);
            }
            else if (obj.Type == TypeManagement.EDITION)
            {
                return _service.Edit(obj.Item);
            }


            return Result.Ok;
        }
    }
}
