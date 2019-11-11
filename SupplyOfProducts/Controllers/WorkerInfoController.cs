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
    public class WorkerInfoController : Controller
    {
        readonly IStep<IWorkerInfoRequest> _supplyBusinessLogic;

        public WorkerInfoController(IStep<IWorkerInfoRequest> supplyBusinessLogic)
        {
            _supplyBusinessLogic = supplyBusinessLogic;
        }

        public class WorkerInfo : IWorkerInfoRequest
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
            WorkerInfo request = new WorkerInfo
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
