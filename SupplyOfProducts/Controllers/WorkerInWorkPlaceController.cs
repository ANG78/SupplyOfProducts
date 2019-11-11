using Microsoft.AspNetCore.Mvc;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Api.Controllers.ViewModels;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using AutoMapper;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerInWorkPlaceController : ControllerGenericNotSingleCodeBase<IWorkerInWorkPlace, WorkerInWorkPlaceViewModel, ResponseWorkerInWorkPlaceViewModel>
    {

        public WorkerInWorkPlaceController(IMapper mapper,
                                IStep<IManagementModelRetrieverRequest<IWorkerInWorkPlace>> serviceBusinessLogic,
                                IStep<IManagementModelRequest<IWorkerInWorkPlace>> businessLogic)
                    : base(mapper, serviceBusinessLogic, businessLogic)
        {
        }


    }

    
}