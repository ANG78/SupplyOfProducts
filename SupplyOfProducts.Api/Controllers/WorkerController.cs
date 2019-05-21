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
    public class WorkerController : ControllerBase
    {
        readonly IWorkerService _serviceBusinessLogic;
        readonly IStep<IManagementModelRequest<IWorker>> _businessLogic;
        private readonly IMapper _mapper;

        public WorkerController(IMapper mapper,
                                IWorkerService serviceBusinessLogic,
                                IStep<IManagementModelRequest<IWorker>> businessLogic)
        {
            _serviceBusinessLogic = serviceBusinessLogic;
            _businessLogic = businessLogic;
            _mapper = mapper;
        }

        // GET: api/Worker
        [HttpGet]
        public IEnumerable<IWorker> Get()
        {
            return _serviceBusinessLogic.GetAll();
        }

        [HttpGet("{code}", Name = "Get")]
        public IWorker Get(string code)
        {
            return _serviceBusinessLogic.Get(code);
        }

        // POST: api/Worker
        [HttpPost]
        public string Post([FromBody] WorkerViewModel value)
        {

            var request = new ManagementModelRequest<IWorker>
            {
                Item = _mapper.Map<IWorker>(value),
                Type = TypeManagement.NEW
            };

            var result = _businessLogic.Execute(request);
            return result.Message();
        }

        // PUT: api/Worker/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] WorkerViewModel value)
        {
            var request = new ManagementModelRequest<IWorker>
            {
                Item = _mapper.Map<IWorker>(value),
                Type = TypeManagement.EDITION
            };

            value.Id = id;

            var result = _businessLogic.Execute(request);
            return result.Message();
        }

    }
}
