using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SupplyOfProducts.Api.Controllers.ViewModels;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;

namespace SupplyOfProducts.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerGenericBase<IWorker, IWorkerService, WorkerViewModel, WorkerViewModel>
    {

        public WorkerController(IMapper mapper,
                                IWorkerService serviceBusinessLogic,
                                  IStep<IManagementModelRequest<IWorker>> businessLogic
                                  ) : base(mapper, serviceBusinessLogic, businessLogic)
        {

        }

    }

   
}
