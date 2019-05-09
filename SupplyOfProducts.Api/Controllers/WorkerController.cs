using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;

namespace SupplyOfProducts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        readonly IWorkerService _supplyBusinessLogic;

        public WorkerController(IWorkerService supplyBusinessLogic)
        {
            _supplyBusinessLogic = supplyBusinessLogic;
        }


        // GET: api/Worker
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Worker/5
       // [HttpGet("{id}", Name = "Get")]
      //  public string Get(int id)
      //  {
            //    WorkerInfoRequest request = new WorkerInfoRequest
            //      {
            //         Worker = new Worker { Code = sCode }
            //   };

            //    var resProductSupplied = _supplyBusinessLogic.Execute(request);
            //    if (resProductSupplied.ComputeResult().IsError())
            //    {
            //        return Mappers.SetStatusProperty(new ResponseWorkerViewModel(), resProductSupplied);
            //    }

            //    return Mappers.Get(request);
        //    return "";
      //  }

        [HttpGet("{code}", Name = "Get")]
        public IWorker Get(string code)
        {
            return _supplyBusinessLogic.Get(code).GetItem();

        }

        // POST: api/Worker
        [HttpPost]
        public void Post([FromBody] IWorker value)
        {
        }

        // PUT: api/Worker/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
