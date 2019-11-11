using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SupplyOfProducts.Api.Controllers
{

    public abstract class AbstractControllerGenericBase : ControllerBase
    {
        protected Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }

    public abstract class ControllerGenericBase<TModel, TModelView, TModelViewGet> :
            ControllerGenericBaseRead<TModel, TModelView, TModelViewGet>
        where TModel : IId
        where TModelViewGet : new()
    {
        protected readonly IStep<IManagementModelRequest<TModel>> _businessLogic;

        public ControllerGenericBase(IMapper mapper,
                                     IStep<IManagementModelRetrieverRequest<TModel>> retrieverbusinessLogic,
                                     IStep<IManagementModelRequest<TModel>> businessLogic
                                   ) : base(mapper, retrieverbusinessLogic)
        {
            _businessLogic = businessLogic;

        }

        // POST: api/WorkPlace
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TModelView value)
        {
            return await Task.Run<ActionResult>(() =>
            {

                var request = new ManagementModelRequest<TModel>
                {
                    Item = _mapper.Map<TModel>(value),
                    Type = Operation.NEW
                };

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

