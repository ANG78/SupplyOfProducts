using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;

namespace SupplyOfProducts.BusinessLogic.Steps
{
    public class ValidateAndCompleteWorkPlace : StepDecoratorTemplateGeneric<IRequestMustBeCompleted>
    {
        private readonly IWorkPlaceService _workplaceService;

        public ValidateAndCompleteWorkPlace(IWorkPlaceService workplaceService,
                                            IStep<IRequestMustBeCompleted> next = null) : base(next)
        {
            _workplaceService = workplaceService;
        }


        public override string Description()
        {
            return "Check the WorkPlace Code";
        }

        protected override IResult ExecuteTemplate(IRequestMustBeCompleted obj)
        {
            if (obj is IContainWorkerProperty)
            {
                return ExecuteTemplate((IContainWorkerProperty)obj);
            }
            else if (obj is IContainWorkerInWorkPlaceProperty)
            {
                var objCasted = (IContainWorkerInWorkPlaceProperty)obj;
                return ExecuteTemplate(objCasted.WorkerInWorkPlace);
            }
            return Result.Ok;
        }

        private IResult ExecuteTemplate(IContainWorkerProperty obj)
        {
 
                var objCasted = (IContainWorkPlaceProperty)obj;
                var resWorkPlaceObject = _workplaceService.Get(objCasted.WorkPlace.Code);

                if (resWorkPlaceObject.ComputeResult().IsError())
                {
                    return resWorkPlaceObject;
                }

                objCasted.WorkPlace = resWorkPlaceObject.GetItem();
                objCasted.WorkPlaceId = resWorkPlaceObject.GetItem().Id;

                if (objCasted.WorkPlace == null || objCasted.WorkPlaceId == 0)
                {
                    return new Result(EnumResultBL.ERROR_WORKPLACE_REQUIRED);
                }
            
            
            return Result.Ok;


        }
    }

}
