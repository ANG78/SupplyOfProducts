using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using System.Threading.Tasks;

namespace SupplyOfProducts.Api.Controllers
{
    public abstract class ControllerGenericBaseComplete<TModel, TModelView, TModelViewGet> :
        ControllerGenericBase<TModel, TModelView, TModelViewGet>
        where TModel : IId
        where TModelViewGet : new()
    {

        public ControllerGenericBaseComplete(IMapper mapper,
                                     IStep<IManagementModelRetrieverRequest<TModel>> serviceBusinessLogic,
                                     IStep<IManagementModelRequest<TModel>> businessLogic
                                   ) : base(mapper, serviceBusinessLogic, businessLogic)
        {

        }

        // PUT: api/WorkPlace/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TModelView value)
        {
            return await Task.Run<ActionResult>(() =>
            {
                var request = new ManagementModelRequest<TModel>
                {
                    Item = _mapper.Map<TModel>(value),
                    Type = Operation.EDITION
                };

                request.Item.Id = id;

                var result = _businessLogic.Execute(request);
                if (result.ComputeResult().IsOk())
                {
                    return Ok(result.Message());
                }

                return BadRequest(result.Message());
            });
        }
    }

}

