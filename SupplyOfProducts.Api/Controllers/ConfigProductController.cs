using Microsoft.AspNetCore.Mvc;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.BusinessLogic.Mappers;
using SupplyOfProducts.Api.Controllers.ViewModels;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Annotations;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;

namespace SupplyOfProducts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigProductController : ControllerBase
    {
        
        readonly IStep<IConfigSupplyRequest> supplyBusinessLogic;

        public ConfigProductController(IStep<IConfigSupplyRequest> psupplyBusinessLogic)
        {
            this.supplyBusinessLogic = psupplyBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerResponse(statusCode: 200, description: "The request for product supply configuration for a worker.", type: typeof(IEnumerable<StatusCodeResult>))]
        public ResponseConfigViewModel SupplyProductToWorker([FromBody] RequestConfigSupplyViewModel configRequest)
        {

            var model = Mappers.Get(configRequest);

            var result = supplyBusinessLogic.Execute(model);
            if (result.ComputeResult().IsError())
            {
                return Mappers.SetStatusProperty(new ResponseConfigViewModel(), result);
            }

            var finalResult = Mappers.Get(model);

            return finalResult;

        }




    }
}
