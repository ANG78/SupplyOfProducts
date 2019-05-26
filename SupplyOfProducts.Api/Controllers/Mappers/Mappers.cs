using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Api.Controllers.ViewModels;
using System;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System.Collections.Generic;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Provision;
using System.Linq;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;

namespace SupplyOfProducts.BusinessLogic.Mappers
{

    public static class Mappers
    {

        public static ConfigSupply Get(ConfigSupplyViewModel request)
        {
            ConfigSupply configSupply = new ConfigSupply
            {
                WorkerInWorkPlace = new WorkerInWorkPlace { Worker = new Worker { Code = request.WorkerCode }, WorkPlace = new WorkPlace { Code = request.WorkPlaceCode } },
                Product = new Product { Code = request.ProductCode },
                Date = request.Date ?? DateTime.Now,
                Amount = request.Amount
            };

            return configSupply;
        }

        public static IProductSupplyRequest Get(RequestSupplyViewModel request)
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
                PartNumber = obj.ProductStock?.Code,
                ProductCode = obj.ProductStock?.Product?.Code,
                Type = obj.ProductStock?.Product?.Type,

            };
        }

        public static ResponseSuppliedViewModel Get(IProductSupplyRequest request)
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

            requestSupplied.Request.ProductSupplied = Get(request.ProductsSupplied[0]);

            //if (request.ProductsSupplied[0]?.ProductStock is IPackageStock)
            //{
            //    IPackageStock pack = (IPackageStock)request.ProductsSupplied[0]?.ProductStock;
            //    requestSupplied.Request.ProductSupplied.Parts = new List<ProductSuppliedViewModel>();
            //    foreach (var pr in pack.Parts)
            //    {
            //        var prNew = new ProductSuppliedViewModel
            //        {
            //            Id = pr.Id,
            //            PartNumber = pr.Code,
            //            ProductCode = pr.Product?.Code
            //        };
            //        requestSupplied.Request.ProductSupplied.Parts.Add(prNew);
            //    }
            //}

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



        public static ResponseWorkerViewModel Get(IWorkerInfoRequest requestWorkerReport)
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

                if (it.ProductsSupplied.Count > 0)
                {
                    iteratorPlace.ProductSupplied.Add(Get(it.ProductsSupplied[0]));
                }
                
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
