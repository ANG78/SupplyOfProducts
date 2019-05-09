using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using System.Linq;

namespace SupplyOfProducts.BusinessLogic.Steps
{
    public class ValidateAndCompleteWorkerInWorkPlace : StepDecoratorTemplateGeneric<IRequestMustBeCompleted>
    {
        readonly IWorkerService _workerService;
        readonly IWorkerInWorkPlaceService _workerInWorkPlaceService;

        public ValidateAndCompleteWorkerInWorkPlace(IWorkerInWorkPlaceService workerInWorkPlaceService,
                                                    IStep<IRequestMustBeCompleted> next = null) : base(next)
        {
            _workerInWorkPlaceService = workerInWorkPlaceService;
        }

        public override string Description()
        {
            return "Check the relatioship between  Worker and WorkPlace taking into account the request date";
        }

        protected override IResult ExecuteTemplate(IRequestMustBeCompleted obj)
        {
            if (obj is IContainWorkerInWorkPlaceProperty && obj is IContainDatePeriodProperty)
            {
                var objCasted = (IContainWorkerInWorkPlaceProperty)obj;
                var objDateCasted = (IContainDatePeriodProperty)obj;
                var placesWhereHaveWorkedInThisDate = _workerInWorkPlaceService.GetWorkPlaceWhereWorkedTheWorker(objCasted.WorkerInWorkPlace.Worker.Code, objDateCasted.Date);

                var placesWhereHaveWorkedInThisDateBeingWorkPlace = placesWhereHaveWorkedInThisDate.Where(x => x.WorkPlace.Code == objCasted.WorkerInWorkPlace.WorkPlace.Code).ToList();
                if (placesWhereHaveWorkedInThisDateBeingWorkPlace.Count != 1)
                {
                    return new Result(EnumResultBL.ERROR_WORKER_DOES_NOT_WORK_IN_THIS_WORKPLACE_IN_THIS_DATE, objCasted.WorkerInWorkPlace.Worker.Code, objCasted.WorkerInWorkPlace.WorkPlace.Code, objDateCasted.Date);
                }

                objCasted.WorkerInWorkPlace = placesWhereHaveWorkedInThisDateBeingWorkPlace[0];
                objCasted.WorkerInWorkPlaceId = placesWhereHaveWorkedInThisDateBeingWorkPlace[0].Id;

            }


            return Result.Ok;
        }
    }
}
