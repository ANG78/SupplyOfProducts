using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using System.Linq;

namespace SupplyOfProducts.BusinessLogic.Steps
{
    public class ValidateAndCompleteWorkerInWorkPlace : StepTemplateGeneric<IRequestMustBeCompleted>
    {
        readonly IWorkerInWorkPlaceService _workerInWorkPlaceService;

        public ValidateAndCompleteWorkerInWorkPlace(IWorkerInWorkPlaceService workerInWorkPlaceService)
        {
            _workerInWorkPlaceService = workerInWorkPlaceService;
        }

        public override string Description()
        {
            return "Check the relationship between  Worker and WorkPlace taking into account the request date";
        }

        protected override IResult ExecuteTemplate(IRequestMustBeCompleted obj)
        {
            var objPeriod = obj.HelperCast<IContainDatePeriodProperty>(obj);

            if (objPeriod != null)
            {
                 var objCasted = obj.HelperCast<IContainWorkerInWorkPlaceProperty>(obj);


                if (objCasted != null)
                {

                    var placesWhereHaveWorkedInThisDate = _workerInWorkPlaceService.GetWorkPlaceWhereWorkedTheWorker(objCasted.WorkerInWorkPlace.Worker.Code, objPeriod.Date);

                    var placesWhereHaveWorkedInThisDateBeingWorkPlace = placesWhereHaveWorkedInThisDate.Where(x => x.WorkPlace.Code == objCasted.WorkerInWorkPlace.WorkPlace.Code).ToList();
                    if (placesWhereHaveWorkedInThisDateBeingWorkPlace.Count != 1)
                    {
                        return new Result(EnumResultBL.ERROR_WORKER_DOES_NOT_WORK_IN_THIS_WORKPLACE_IN_THIS_DATE, objCasted.WorkerInWorkPlace.Worker.Code, objCasted.WorkerInWorkPlace.WorkPlace.Code, objPeriod.Date);
                    }

                    objCasted.WorkerInWorkPlace = placesWhereHaveWorkedInThisDateBeingWorkPlace.First();
                    objCasted.WorkerInWorkPlaceId = placesWhereHaveWorkedInThisDateBeingWorkPlace.First().Id;

                }
            }


            return Result.Ok;
        }
    }
}
