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
    public class WorkPlaceController : ControllerGenericBase<IWorkPlace, WorkPlaceViewModel, WorkPlaceViewModel>
    {

        public WorkPlaceController(IMapper mapper,
                                IStep<IManagementModelRequest<IWorkPlace>> businessLogic,
                                IStep<IManagementModelRetrieverRequest<IWorkPlace>> businessRetrieverLogic
                               ) : base(mapper, businessRetrieverLogic, businessLogic)
        {

        }

    }

}

