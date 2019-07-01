using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SupplyOfProducts.Api.Controllers
{
    public abstract class ControllerGenericBaseRead<TModel, TModelView, TModelViewGet> : 
        ControllerBase where TModel : IId
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

            var resut = _retrieverBusinessLogic.Execute(request);
            if (resut.ComputeResult().IsOk())
            {
                return _mapper.Map<IEnumerable<TModelViewGet>>(request.Items);
            }

            throw new Exception(resut.Message());

        }

        [HttpGet("{code}", Name = "Get[controller]")]
        public TModelViewGet Get(string code)
        {
            var request = new ManagementModelRetrieverRequest<TModel>
            {
                Code = code
            };


            var resut = _retrieverBusinessLogic.Execute(request);
            if (!resut.ComputeResult().IsOk()
                ||
                request.Items?.Count() != 1)
            {
                throw new Exception(resut.Message());
            }

            return _mapper.Map<TModelViewGet>(request.Items.ToList()[0]);

        }
    }

    public abstract class ControllerGenericBase<TModel, TModelView, TModelViewGet> : 
            ControllerGenericBaseRead<TModel, TModelView, TModelViewGet>  where TModel : IId
    {
        protected readonly IStep<IManagementModelRequest<TModel>> _businessLogic;

        public ControllerGenericBase(IMapper mapper,
                                     IStep<IManagementModelRetrieverRequest<TModel>> retrieverbusinessLogic,
                                     IStep<IManagementModelRequest<TModel>> businessLogic
                                   ):base( mapper, retrieverbusinessLogic)
        {
            _businessLogic = businessLogic;

        }

        // POST: api/WorkPlace
        [HttpPost]
        public string Post([FromBody] TModelView value)
        {

            var request = new ManagementModelRequest<TModel>
            {
                Item = _mapper.Map<TModel>(value),
                Type = Operation.NEW
            };

            var result = _businessLogic.Execute(request);
            return result.Message();
        }
      
    }
    
    public abstract class ControllerGenericBaseComplete<TModel, TModelView, TModelViewGet> : 
        ControllerGenericBase<TModel, TModelView, TModelViewGet> where TModel : IId
    {

        public ControllerGenericBaseComplete(IMapper mapper,
                                     IStep<IManagementModelRetrieverRequest<TModel>>  serviceBusinessLogic,
                                     IStep<IManagementModelRequest<TModel>> businessLogic
                                   ) : base(mapper, serviceBusinessLogic, businessLogic)
        {
            
        }

        // PUT: api/WorkPlace/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] TModelView value)
        {
            var request = new ManagementModelRequest<TModel>
            {
                Item = _mapper.Map<TModel>(value),
                Type = Operation.EDITION
            };

            request.Item.Id = id;

            var result = _businessLogic.Execute(request);
            return result.Message();
        }
    }
    
}

