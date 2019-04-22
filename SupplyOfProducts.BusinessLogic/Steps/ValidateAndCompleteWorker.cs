using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;

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
            if (obj is IContainWorkerProperty)
            {
                var objCasted = (IContainWorkerProperty)obj;
                var resWorkerObject = _workerRepository.Get(objCasted.Worker.Code);
                if (resWorkerObject.ComputeResult().IsError())
                {
                    return resWorkerObject;
                }
                objCasted.Worker = resWorkerObject.GetItem();
                objCasted.IdWorker = resWorkerObject.GetItem().Id;
            }
            else if (obj is IContainWorkerInWorkPlaceProperty)
            {
                var objCasted = (IContainWorkerInWorkPlaceProperty)obj;
                return ExecuteTemplate(objCasted.WorkerInWorkPlace);
            }

            return Result.Ok;
        }
    }

}