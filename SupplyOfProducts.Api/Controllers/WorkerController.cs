using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SupplyOfProducts.Api.Controllers.ViewModels;
using SupplyOfProducts.BusinessLogic.Mappers;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;


namespace SupplyOfProducts.Api.Controllers
{
    [Route("api/[controller]")]
    public class WorkerController : Controller
    {
        readonly IStep<IWorkerInfo> _supplyBusinessLogic;

        public WorkerController(IStep<IWorkerInfo> supplyBusinessLogic)
        {
            _supplyBusinessLogic = supplyBusinessLogic;
        }

        public class WorkerInfo : IWorkerInfo
        {
            public int IdWorker { get ; set ; }
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
