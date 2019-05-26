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
    public class ProductStockController : ControllerBase
    {
        readonly IProductStockService _serviceBusinessLogic;
        readonly IStep<IManagementModelRequest<IProductStock>> _businessLogic;
        private readonly IMapper _mapper;

        public ProductStockController(IMapper mapper,
                                IProductStockService serviceBusinessLogic,
                                IStep<IManagementModelRequest<IProductStock>> businessLogic)
        {
            _serviceBusinessLogic = serviceBusinessLogic;
            _businessLogic = businessLogic;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ProductStockViewModel> Get()
        {
            var result = _serviceBusinessLogic.GetAll();
            var resultMapped = _mapper.Map<IEnumerable<ProductStockViewModel>>(result);
            return resultMapped;
        }

        [HttpGet("{code}", Name = "GetProductStock")]
        public ProductStockViewModel GetProduct(string code)
        {
            var result = _serviceBusinessLogic.Get(code);
            var resultMapped = _mapper.Map<ProductStockViewModel>(result);
            return resultMapped;
        }

        [HttpPost]
        public string Post([FromBody] ProductStockViewModel value)
        {

            var request = new ManagementModelRequest<IProductStock>
            {
                Item = _mapper.Map<IProductStock>(value),
                Type = Operation.NEW
            };

            var result = _businessLogic.Execute(request);
            return result.Message();
        }

        [HttpPut("{id}")]
        public string Put(int id, [FromBody] ProductStockViewModel value)
        {
            value.Id = id;

            var request = new ManagementModelRequest<IProductStock>
            {
                Item = _mapper.Map<IProductStock>(value),
                Type = Operation.EDITION
            };


            var result = _businessLogic.Execute(request);
            return result.Message();
        }
    }
}
