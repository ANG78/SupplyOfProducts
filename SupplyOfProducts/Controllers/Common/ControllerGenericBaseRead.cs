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
        public async Task<IEnumerable<TModelViewGet>> Get()
        {
            //return await Task.FromException<IEnumerable<TModelViewGet>>(new Exception("result.Message()"));

            return await Task<IEnumerable<TModelViewGet>>.Run(() =>
            {

                var request = new ManagementModelRetrieverRequest<TModel> { };

                var result = _retrieverBusinessLogic.Execute(request);
                if (!result.ComputeResult().IsOk())
                {
                    return  Task.FromException<IEnumerable<TModelViewGet>>(new Exception(result.Message())).Result;
                }

                return _mapper.Map<IEnumerable<TModelViewGet>>(request.Items);

            });
        }

        [HttpGet("{code}", Name = "Get[controller]")]
        public async Task<TModelViewGet> Get(string code)
        {
            return await Task.Run<TModelViewGet>(() =>
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

                var resultGot = _mapper.Map<TModelViewGet>(request.Items.ToList()[0]);
                return resultGot;
            });
        }

    }

}

