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
                                            IStep<IRequestMustBeCompleted> next = null)
        {
            _workplaceService = workplaceService;
        }


        public override string Description()
        {
            return "Check the WorkPlace Code";
        }

        protected override IResult ExecuteTemplate(IRequestMustBeCompleted obj)
        {

            IContainWorkPlaceProperty objToProces = null;
            obj.HelperCast(obj, ref objToProces);

            if (objToProces != null)
            {
                return ExecuteTemplate(objToProces);
            }

            IContainWorkerInWorkPlaceProperty objToProces2 = null;
            obj.HelperCast(obj, ref objToProces2);

            if (objToProces2 != null)
            {
                return ExecuteTemplate(objToProces2.WorkerInWorkPlace);
            }

            if (obj is IContainWorkPlaceProperty)
            {
                return ExecuteTemplate((IContainWorkPlaceProperty)obj);
            }
            else if (obj is IContainWorkerInWorkPlaceProperty)
            {
                var objCasted = (IContainWorkerInWorkPlaceProperty)obj;
                return ExecuteTemplate(objCasted.WorkerInWorkPlace);
            }
            return Result.Ok;
        }

        private IResult ExecuteTemplate(IContainWorkPlaceProperty obj)
        {
 
                var objCasted = obj;
                var resWorkPlaceObject = _workplaceService.CheckExist(objCasted.WorkPlace.Code);

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
