﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using System.Collections.Generic;

namespace SupplyOfProducts.Api.Controllers
{
    public abstract class ControllerGenericNotSingleCodeBaseRead<TModel, TService, TModelView, TModelViewGet> : ControllerBase where TService : IGenericNotSingleCodeReadService<TModel> where TModel : IId
    {
        protected readonly TService _service;
        protected readonly IMapper _mapper;

        public ControllerGenericNotSingleCodeBaseRead(IMapper mapper, TService serviceBusinessLogic)
        {
            _service = serviceBusinessLogic;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<TModelViewGet> Get()
        {
            var res = _service.GetAll();
            return _mapper.Map<IEnumerable<TModelViewGet>>(res);
        }

        [HttpGet("{code}", Name = "Get[controller]")]
        public IEnumerable<TModelViewGet> Get(string code)
        {
            var res = _service.Get(code);
            return _mapper.Map<IEnumerable<TModelViewGet>>(res);
        }
    }


    public abstract class ControllerGenericNotSingleCodeBase<TModel, TService, TModelView, TModelViewGet> : ControllerGenericNotSingleCodeBaseRead<TModel, TService, TModelView, TModelViewGet> where TService : IGenericNotSingleCodeService<TModel> where TModel : IId
    {
        protected readonly IStep<IManagementModelRequest<TModel>> _businessLogic;

        public ControllerGenericNotSingleCodeBase(IMapper mapper,
                                     TService serviceBusinessLogic,
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
