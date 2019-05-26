using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SupplyOfProducts.Api.Controllers.ViewModels;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;

namespace SupplyOfProducts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IProductService _serviceBusinessLogic;
        readonly IStep<IManagementModelRequest<IProduct>> _businessLogic;
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper,
                                IProductService serviceBusinessLogic,
                                IStep<IManagementModelRequest<IProduct>> businessLogic)
        {
            _serviceBusinessLogic = serviceBusinessLogic;
            _businessLogic = businessLogic;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ProductViewModel> Get()
        {
            var result = _serviceBusinessLogic.GetAll();
            var resultMapped = _mapper.Map< IEnumerable<ProductViewModel> >(result);
            return resultMapped;
        }
      
        [HttpGet("{code}", Name = "GetProduct" )]
        public ProductViewModel GetProduct(string code)
        {
            var result = _serviceBusinessLogic.Get(code);
            var resultMapped = _mapper.Map<ProductViewModel>(result);
            return resultMapped;
        }

        [HttpPost]
        public string Post([FromBody] ProductViewModel value)
        {

            var request = new ManagementModelRequest<IProduct>
            {
                Item = _mapper.Map<IProduct>(value),
                Type = Operation.NEW
            };

            var result = _businessLogic.Execute(request);
            return result.Message();
        }

        [HttpPut("{id}")]
        public string Put(int id, [FromBody] ProductViewModel value)
        {
            value.Id = id;

            var request = new ManagementModelRequest<IProduct>
            {
                Item = _mapper.Map<IProduct>(value),
                Type = Operation.EDITION
            };


            var result = _businessLogic.Execute(request);
            return result.Message();
        }
    }
}
