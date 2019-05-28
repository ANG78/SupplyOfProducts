using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;

namespace SupplyOfProducts.BusinessLogic.Steps
{

    public class ValidateAndCompleteWorker : StepDecoratorTemplateGeneric<IRequestMustBeCompleted>
    {
        readonly IWorkerService _workerRepository;

        public ValidateAndCompleteWorker(IWorkerService workerService,
                                         IStep<IRequestMustBeCompleted> next = null) : base(next)
        {
            _workerRepository = workerService;
        }

        public override string Description()
        {
            return "Check and complete the Worker Code";
        }

        protected override IResult ExecuteTemplate(IRequestMustBeCompleted obj)
        {
            IContainWorkerProperty objToProces = null;
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

        private IResult ExecuteTemplate(IContainWorkerProperty objCasted)
        {
            var resWorkerObject = _workerRepository.CheckExist(objCasted.Worker.Code);
            if (resWorkerObject.ComputeResult().IsError())
            {
                return resWorkerObject;
            }
            objCasted.Worker = resWorkerObject.GetItem();
            objCasted.WorkerId = resWorkerObject.GetItem().Id;

            return Result.Ok;
        }
    }

}