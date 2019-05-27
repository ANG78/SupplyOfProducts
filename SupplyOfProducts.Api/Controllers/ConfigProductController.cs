using Microsoft.AspNetCore.Mvc;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Api.Controllers.ViewModels;
using System.Collections.Generic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using AutoMapper;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;

namespace SupplyOfProducts.Api.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ConfigProductController : ControllerGenericBase<IConfigSupply, IConfigSupplyService, ConfigSupplyViewModel, ConfigSupplyViewModelExt>
    {

        public ConfigProductController(IMapper mapper,
                                IConfigSupplyService serviceBusinessLogic,
                                IStep<IManagementModelRequest<IConfigSupply>> businessLogic)
                    : base(mapper, serviceBusinessLogic, businessLogic )
        {
        }

        [HttpGet("{workerCode}", Name = "GetAll[controller]")]
        public IEnumerable<ConfigSupplyViewModelExt> GetAllByWorker(string workerCode)
        {
            var result = _service.GetAll(workerCode);
            var resultMapped = _mapper.Map<IEnumerable<ConfigSupplyViewModelExt>>(result);
            return resultMapped;
        }
    }
}

