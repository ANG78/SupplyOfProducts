using Microsoft.AspNetCore.Mvc;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Api.Controllers.ViewModels;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using AutoMapper;

namespace SupplyOfProducts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigProductController : ControllerGenericNotSingleCodeBase<IConfigSupply, ConfigSupplyViewModel, ConfigSupplyViewModelExt>
    {

        public ConfigProductController(IMapper mapper,
                                IStep<IManagementModelRetrieverRequest<IConfigSupply>> serviceBusinessLogic,
                                IStep<IManagementModelRequest<IConfigSupply>> businessLogic)
                    : base(mapper, serviceBusinessLogic, businessLogic )
        {
        }

       
    }
}

