using Microsoft.AspNetCore.Mvc;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using System.Collections.Generic;

namespace SupplyOfProducts.Api.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class WorkPlaceController : ControllerBase
    {
        readonly IWorkPlaceService _service;
        readonly IStep<IManagementModelRequest<IWorkPlace>> _businessLogic;

        public WorkPlaceController(IWorkPlaceService serviceBusinessLogic,
                                   IStep<IManagementModelRequest<IWorkPlace>> businessLogic)
        {
            _service = serviceBusinessLogic;
            _businessLogic = businessLogic;
        }

        // GET: api/WorkPlace
        [HttpGet]
        public IEnumerable<IWorkPlace> Get()
        {
            return _service.GetAll();
        }

        [HttpGet("{code}", Name = "GetWorkPlace")]
        public IWorkPlace GetWorkPlace(string code)
        {
            return _service.Get(code);
        }

        // POST: api/WorkPlace
        [HttpPost]
        public string Post([FromBody] WorkPlace value)
        {

            var request = new ManagementModelRequest<IWorkPlace>
            {
                Item = value,
                Type = TypeManagement.NEW
            };

            var result = _businessLogic.Execute(request);
            return result.Message();
        }

        // PUT: api/WorkPlace/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] WorkPlace value)
        {
            var request = new ManagementModelRequest<IWorkPlace>
            {
                Item = value,
                Type = TypeManagement.EDITION
            };

            value.Id = id;

            var result = _businessLogic.Execute(request);
            return result.Message();
        }

    }
}

