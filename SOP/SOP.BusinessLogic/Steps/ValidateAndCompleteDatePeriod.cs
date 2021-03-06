﻿using SupplyOfProducts.BusinessLogic.Common;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using System;

namespace SupplyOfProducts.BusinessLogic.Steps
{
    public class ValidateAndCompleteDatePeriod : StepTemplateGeneric<IRequestMustBeCompleted>
    {
        readonly IPeriodConfigurationService periodConfigurationService;

        public ValidateAndCompleteDatePeriod(IPeriodConfigurationService _periodConfigurationService) 
        {
            periodConfigurationService = _periodConfigurationService;
        }

        public override string Description()
        {
            return "Calculate the Date Period taking into account its Date Property.";
        }

        protected override IResult ExecuteTemplate(IRequestMustBeCompleted obj)
        {

            IContainDatePeriodProperty objPeriod = obj.HelperCast<IContainDatePeriodProperty>(obj);

            if (objPeriod != null)
            {
                var objCasted = obj.HelperCast<IContainWorkerInWorkPlaceProperty>(obj);

                if (objCasted!=null)
                {

                    var resDateComputaded = periodConfigurationService.ComputeDate(objCasted.WorkerInWorkPlace, objPeriod.Date);

                    if (resDateComputaded.ComputeResult().IsError())
                    {
                        return resDateComputaded;
                    }

                    objPeriod.PeriodDate = resDateComputaded.GetItem().Date;

                }
            }
            return Result.Ok;
        }
    }
}
