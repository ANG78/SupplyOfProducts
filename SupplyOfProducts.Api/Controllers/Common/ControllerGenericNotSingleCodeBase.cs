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
    public abstract class ControllerGenericNotSingleCodeBaseRead<TModel,  TModelView, TModelViewGet> : ControllerBase 
        where TModel : IId
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
        public IEnumerable<TModelViewGet> Get()
        {
            var request = new ManagementModelRetrieverRequest<TModel> { };

            var resut = _retrieverBusinessLogic.Execute(request);
            if (resut.ComputeResult().IsOk())
            {
                return _mapper.Map<IEnumerable<TModelViewGet>>(request.Items);
            }

            throw new Exception(resut.Message());

            //var res = _service.GetAll();
            //return _mapper.Map<IEnumerable<TModelViewGet>>(res);
        }

        [HttpGet("{code}", Name = "Get[controller]")]
        public IEnumerable<TModelViewGet> Get(string code)
        {
            var request = new ManagementModelRetrieverRequest<TModel>
            {
                Code = code
            };


            var resut = _retrieverBusinessLogic.Execute(request);
            if (!resut.ComputeResult().IsOk()
                &&
                request.Items?.Count() != 1)
            {
                throw new Exception(resut.Message());
            }

            return _mapper.Map<IEnumerable<TModelViewGet>>(request.Items.ToList());
            //var res = _service.Get(code);
            //return _mapper.Map<IEnumerable<TModelViewGet>>(res);;
        }
    }


    public abstract class ControllerGenericNotSingleCodeBase<TModel, TModelView, TModelViewGet> : 
        ControllerGenericNotSingleCodeBaseRead<TModel, TModelView, TModelViewGet> where TModel : IId
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

}
