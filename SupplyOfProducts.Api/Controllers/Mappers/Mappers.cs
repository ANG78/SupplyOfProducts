using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Api.Controllers.ViewModels;
using System;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System.Collections.Generic;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Provision;
using System.Linq;

namespace SupplyOfProducts.BusinessLogic.Mappers
{

    public static class Mappers
    {

        public static ConfigSupply Get(RequestConfigSupplyViewModel request)
        {
            ConfigSupply configSupply = new ConfigSupply
            {
                WorkerInWorkPlace = new WorkerInWorkPlace { Worker = new Worker { Code = request.CodeWorker }, WorkPlace = new WorkPlace { Code = request.CodeWorkPlace } },
                Product = new Product { Code = request.CodeProduct },
                Date = request.Date ?? DateTime.Now,
                Amount = request.Amount
            };

            return configSupply;
        }

        public static ProductSupply Get(RequestSupplyViewModel request)
        {
            ProductSupply requestProduct = new ProductSupply
            {
                WorkerInWorkPlace = new WorkerInWorkPlace { Worker = new Worker { Code = request.CodeWorker }, WorkPlace = new WorkPlace { Code = request.CodeWorkPlace } },
                Product = new Product { Code = request.CodeProduct },
                Date = request.Date ?? DateTime.Now
            };

            return requestProduct;
        }

        public static ProductSuppliedViewModel Get(IProductSupplied obj)
        {
            return new ProductSuppliedViewModel
            {
                Id = obj.Id,
                PartNumber = obj.ProductStock?.PartNumber,
                ProductCode = obj.ProductStock?.Product?.Code,
                Type = obj.ProductStock?.Product?.Type,

            };
        }

        public static ResponseSuppliedViewModel Get(IProductSupply request)
        {
            ResponseSuppliedViewModel requestSupplied = new ResponseSuppliedViewModel
            {
                Request = new ResponseSupplyViewModel
                {
                    CodeWorker = request.Product.Code,
                    CodeWorkPlace = request.WorkerInWorkPlace.WorkPlace?.Code,
                    Period = request.PeriodDate
                }

            };

            requestSupplied.Request.ProductSupplied = Get(request.ProductSupplied);

            if (request.ProductSupplied?.ProductStock is IPackageStock)
            {
                IPackageStock pack = (IPackageStock)request.ProductSupplied?.ProductStock;
                requestSupplied.Request.ProductSupplied.Parts = new List<ProductSuppliedViewModel>();
                foreach (var pr in pack.Parts)
                {
                    var prNew = new ProductSuppliedViewModel
                    {
                        Id = pr.Id,
                        PartNumber = pr.PartNumber,
                        ProductCode = pr.Product?.Code
                    };
                    requestSupplied.Request.ProductSupplied.Parts.Add(prNew);
                }
            }

            return requestSupplied;
        }

        public static ResponseConfigViewModel Get(IConfigSupply request)
        {
            ResponseConfigViewModel result = new ResponseConfigViewModel
            {
                Request = new ResponseConfigRequestViewModel
                {
                    CodeWorker = request.WorkerInWorkPlace?.Worker.Code,
                    CodeWorkPlace = request.WorkerInWorkPlace.WorkPlace?.Code,
                    Period = request.PeriodDate,
                    Amount = request.Amount
                }

            };
            return result;
        }



        public static ResponseWorkerViewModel Get(IWorkerInfo requestWorkerReport)
        {
            var result = new ResponseWorkerViewModel
            {
                CodeWorker = requestWorkerReport.Worker.Code,
                Name = requestWorkerReport.Worker.Name,
            };

            List<ResponseSupplyViewModel> resSupplieds = new List<ResponseSupplyViewModel>();

            IDictionary<IWorkPlace, ResponseSupplyByWorkPlaceViewModel> suppliesGroupByWorkPlace = new Dictionary<IWorkPlace, ResponseSupplyByWorkPlaceViewModel>();
            foreach (var it in requestWorkerReport.ProductSupplies)
            {
                var workPlace = it.WorkerInWorkPlace.WorkPlace;
                ResponseSupplyByWorkPlaceViewModel iteratorPlace = null;
                if (!suppliesGroupByWorkPlace.Keys.Contains(it.WorkerInWorkPlace.WorkPlace))
                {
                    iteratorPlace = new ResponseSupplyByWorkPlaceViewModel
                    {
                        CodeWorkPlace = workPlace.Code
                    };

                    result.ProductSuppliedByWorkPlaces.Add(iteratorPlace);
                }
                else
                {
                    iteratorPlace = suppliesGroupByWorkPlace[workPlace];
                }


                iteratorPlace.ProductSupplied.Add(Get(it.ProductSupplied));
                
            }
            
            return result;
        }

        public static T SetStatusProperty<T>(T response, IResult result) where T : IResponseViewModel
        {
            response.Status = new ResponseViewModel
            {
                IsOk = false,
                Message = result.Message()
            };
            return response;
        }
    }
}
