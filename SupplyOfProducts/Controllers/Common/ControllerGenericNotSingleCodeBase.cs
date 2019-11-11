using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SupplyOfProducts.Api.Controllers
{
    public abstract class ControllerGenericNotSingleCodeBaseRead<TModel, TModelView, TModelViewGet> : AbstractControllerGenericBase
        where TModel : IId
        where TModelViewGet : new()
    {
        protected readonly IStep<IManagementModelRetrieverRequest<TModel>> _retrieverBusinessLogic;
        protected readonly IMapper _mapper;

        public ControllerGenericNotSingleCodeBaseRead(IMapper mapper,
                                                      IStep<IManagementModelRetrieverRequest<TModel>> serviceBusinessLogic)
        {
            _retrieverBusinessLogic = serviceBusinessLogic;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TModelViewGet>> Get()
        {
            return await Task.Run<IEnumerable<TModelViewGet>>(() =>
            {
                var request = new ManagementModelRetrieverRequest<TModel> { };

                var result = _retrieverBusinessLogic.Execute(request);
                if (result.ComputeResult().IsOk())
                {
                    return _mapper.Map<IEnumerable<TModelViewGet>>(request.Items);
                }

                throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound)
                {
                    Source = result.Message()
                };
            });
        }

        [HttpGet("{code}", Name = "Get[controller]")]
        public virtual async Task<IEnumerable<TModelViewGet>> Get(string code)
        {
            return await Task.Run(() =>
            {

                var request = new ManagementModelRetrieverRequest<TModel>
                {
                    Code = code
                };

                var result = _retrieverBusinessLogic.Execute(request);
                if (!result.ComputeResult().IsOk())
                {
                    throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound)
                    {
                        Source = result.Message()
                    };
                }

                return _mapper.Map<IEnumerable<TModelViewGet>>(request.Items.ToList());
                //var res = _service.Get(code);
                //return _mapper.Map<IEnumerable<TModelViewGet>>(res);;
            });
        }
    }


    public abstract class ControllerGenericNotSingleCodeBase<TModel, TModelView, TModelViewGet> :
        ControllerGenericNotSingleCodeBaseRead<TModel, TModelView, TModelViewGet>
        where TModel : IId
        where TModelViewGet : new()
    {
        protected readonly IStep<IManagementModelRequest<TModel>> _businessLogic;

        public ControllerGenericNotSingleCodeBase(IMapper mapper,
                                     IStep<IManagementModelRetrieverRequest<TModel>> serviceBusinessLogic,
                                     IStep<IManagementModelRequest<TModel>> businessLogic
                                   ) : base(mapper, serviceBusinessLogic)
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
