using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SupplyOfProducts.Api.Controllers.ViewModels;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;

namespace SupplyOfProducts.Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class WorkPlaceController : ControllerGenericBase<IWorkPlace,IWorkPlaceService, WorkPlaceViewModel, WorkPlaceViewModel>
    {

        public WorkPlaceController(IWorkPlaceService serviceBusinessLogic,
                                  IStep<IManagementModelRequest<IWorkPlace>> businessLogic,
                                  IMapper mapper): base(serviceBusinessLogic, businessLogic, mapper)
        {
          
        }
        
    }
}

