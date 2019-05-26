using Microsoft.AspNetCore.Mvc;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.BusinessLogic.Mappers;
using SupplyOfProducts.Api.Controllers.ViewModels;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Annotations;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using AutoMapper;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.BusinessLogic.Steps.Common;

namespace SupplyOfProducts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigProductController : ControllerBase
    {
        readonly IConfigSupplyService _serviceBusinessLogic;
        readonly IStep<IManagementModelRequest<IConfigSupply>> _businessLogic;
        private readonly IMapper _mapper;

        public ConfigProductController(IMapper mapper,
                                IConfigSupplyService serviceBusinessLogic,
                                IStep<IManagementModelRequest<IConfigSupply>> businessLogic)
        {
            _serviceBusinessLogic = serviceBusinessLogic;
            _businessLogic = businessLogic;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ConfigSupplyViewModelExt> Get()
        {
            var result = _serviceBusinessLogic.GetAll();
            var resultMapped = _mapper.Map<IEnumerable<ConfigSupplyViewModelExt>>(result);
            return resultMapped;
        }

        [HttpGet("{code}", Name = "Get{controller}")]
        public IEnumerable<ConfigSupplyViewModelExt> Get(string code)
        {
            var result = _serviceBusinessLogic.Get(code);
            var resultMapped = _mapper.Map<IEnumerable<ConfigSupplyViewModelExt>>(result);
            return resultMapped;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerResponse(statusCode: 200, description: "The request for product supply configuration for a worker.", type: typeof(IEnumerable<StatusCodeResult>))]
        public ResponseConfigViewModel Post([FromBody] ConfigSupplyViewModel value)
        {

            var request = new ManagementModelRequest<IConfigSupply>
            {
                Item = _mapper.Map<IConfigSupply>(value),
                Type = Operation.NEW
            };

            var result = _businessLogic.Execute(request);
            if (result.ComputeResult().IsError())
            {
                return Mappers.SetStatusProperty(new ResponseConfigViewModel(), result);
            }
            var finalResult = Mappers.Get(request.Item);

            return finalResult;
          
        }

    }
}
