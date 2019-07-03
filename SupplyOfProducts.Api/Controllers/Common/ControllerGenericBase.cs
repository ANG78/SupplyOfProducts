using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

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
    public abstract class ControllerGenericBaseRead<TModel, TModelView, TModelViewGet> :
        AbstractControllerGenericBase
        where TModel : IId
        where TModelViewGet : new()
    {
        protected readonly IStep<IManagementModelRetrieverRequest<TModel>> _retrieverBusinessLogic;
        protected readonly IMapper _mapper;

        public ControllerGenericBaseRead(IMapper mapper,
                                         IStep<IManagementModelRetrieverRequest<TModel>> retrieverbusinessLogic)
        {
            _retrieverBusinessLogic = retrieverbusinessLogic;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<TModelViewGet> Get()
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

        }

        [HttpGet("{code}", Name = "Get[controller]")]
        public TModelViewGet Get(string code)
        {
            var request = new ManagementModelRetrieverRequest<TModel>
            {
                Code = code
            };


            var result = _retrieverBusinessLogic.Execute(request);
            if (!result.ComputeResult().IsOk()
                ||
                request.Items?.Count() != 1)
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound)
                {
                    Source = result.Message()
                };

            }

            return _mapper.Map<TModelViewGet>(request.Items.ToList()[0]);

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
        public ActionResult Post([FromBody] TModelView value)
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



        }

    }

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
        public ActionResult Put(int id, [FromBody] TModelView value)
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

        }
    }

}

