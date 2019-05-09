using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SupplyOfProducts.Api.Controllers.ViewModels;
using SupplyOfProducts.BusinessLogic.Mappers;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;

namespace SupplyOfProducts.Api.Controllers
{
    [Route("api/[controller]")]
    public class WorkerController : Controller
    {
        readonly IStep<IWorkerInfoRequest> _supplyBusinessLogic;

        public WorkerController(IStep<IWorkerInfoRequest> supplyBusinessLogic)
        {
            _supplyBusinessLogic = supplyBusinessLogic;
        }

        public class WorkerInfoRequest : IWorkerInfoRequest
        {
            public int WorkerId { get ; set ; }
            public IWorker Worker { get ; set ; }
            public IList<IWorkerInWorkPlace> WorkPlaces { get ; set ; }
            public IList<IProductSupply> ProductSupplies { get ; set ; }
        }


        // GET api/<controller>
        [HttpGet]
        public ResponseWorkerViewModel GetWorkerInfo(string sCode)
        {
            WorkerInfoRequest request = new WorkerInfoRequest
            {
                Worker = new Worker { Code = sCode }
            };

            var resProductSupplied = _supplyBusinessLogic.Execute(request);
            if (resProductSupplied.ComputeResult().IsError())
            {
                return Mappers.SetStatusProperty(new ResponseWorkerViewModel(), resProductSupplied);
            }

            return Mappers.Get(request);
        }


        // GET api/<controller>
        [HttpGet]
        public ResponseWorkerViewModel Get(string sCode)
        {
            WorkerInfoRequest request = new WorkerInfoRequest
            {
                Worker = new Worker { Code = sCode }
            };

            var resProductSupplied = _supplyBusinessLogic.Execute(request);
            if (resProductSupplied.ComputeResult().IsError())
            {
                return Mappers.SetStatusProperty(new ResponseWorkerViewModel(), resProductSupplied);
            }

            return Mappers.Get(request);
        }

    }

    
}
