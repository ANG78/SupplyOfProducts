using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using System.Linq;

namespace SupplyOfProducts.BusinessLogic.Steps
{
    public class ValidateAndCompleteWorkerInWorkPlace : StepDecoratorTemplateGeneric<IRequestMustBeCompleted>
    {
        readonly IWorkerService _workerService;

        public ValidateAndCompleteWorkerInWorkPlace(IWorkerService workerService,
                                                    IStep<IRequestMustBeCompleted> next = null) : base(next)
        {
            _workerService = workerService;
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
                var placesWhereHaveWorkedInThisDate = _workerService.GetWorkPlaceWhereWorkedTheWorker(objCasted.WorkerInWorkPlace.Worker.Code, objDateCasted.Date);

                var placesWhereHaveWorkedInThisDateBeingWorkPlace = placesWhereHaveWorkedInThisDate.Where(x => x.WorkPlace.Code == objCasted.WorkerInWorkPlace.WorkPlace.Code).ToList();
                if (placesWhereHaveWorkedInThisDateBeingWorkPlace.Count != 1)
                {
                    return new Result(EnumResultBL.ERROR_WORKER_DOES_NOT_WORK_IN_THIS_WORKPLACE_IN_THIS_DATE, objCasted.WorkerInWorkPlace.Worker.Code, objCasted.WorkerInWorkPlace.WorkPlace.Code, objDateCasted.Date);
                }

                objCasted.WorkerInWorkPlace = placesWhereHaveWorkedInThisDateBeingWorkPlace[0];
                objCasted.IdWorkerInWorkPlace = placesWhereHaveWorkedInThisDateBeingWorkPlace[0].Id;

            }


            return Result.Ok;
        }
    }
}
