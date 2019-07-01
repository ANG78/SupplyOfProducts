using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SupplyOfProducts.Api.Controllers.ViewModels;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;

namespace SupplyOfProducts.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerGenericBase<IWorker, WorkerViewModel, WorkerViewModel>
    {

        public WorkerController(IMapper mapper,
                                IStep<IManagementModelRequest<IWorker>> businessLogic,
                                IStep<IManagementModelRetrieverRequest<IWorker>> businessRetrieverLogic
                               ) : base(mapper, businessRetrieverLogic, businessLogic)
        {

        }

    }

    
}
