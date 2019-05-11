using Microsoft.AspNetCore.Mvc;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.BusinessLogic.Mappers;
using SupplyOfProducts.Api.Controllers.ViewModels;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Annotations;

namespace SupplyOfProducts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplyProductController : ControllerBase
    {
        readonly IStep<IProductSupply> supplyBusinessLogic;

        public SupplyProductController(IStep<IProductSupply> psupplyBusinessLogic)
        {
            this.supplyBusinessLogic = psupplyBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provisionRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerResponse(statusCode: 200, description: "The request for product supply for a worker.", type: typeof(IEnumerable<StatusCodeResult>))]        
        public ResponseSuppliedViewModel SupplyProductToWorker([FromBody] RequestSupplyViewModel provisionRequest)
        {
            
            var model = Mappers.Get(provisionRequest);

            var result = supplyBusinessLogic.Execute(model);
            if (result.ComputeResult().IsError())
            {
                return Mappers.SetStatusProperty(new ResponseSuppliedViewModel(), result);
            }

            var finalResult = Mappers.Get(model);

            return finalResult;

        }

    }
}