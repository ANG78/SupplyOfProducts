using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupplyOfProducts.Api.Controllers.ViewModels;
using SupplyOfProducts.BusinessLogic.Mappers;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using System;

namespace SupplyOfProducts.Test.Services
{
    [TestClass]
    public class TestProductSupplyService : UnitTestServiceBase// UnitTestBase
    {
        [TestMethod]
        public void TestProductSupplyService_IsWorkingProperly()
        {
            Reset();

            IPeriodConfigurationService serviceConfPer = Provider.GetService<IPeriodConfigurationService>();
            IWorkerInWorkPlaceService workerService = Provider.GetService<IWorkerInWorkPlaceService>();

            var wInwps = workerService.GetWorkPlaceWhereWorkedTheWorker(workerMocked, null);
            Assert.IsTrue(wInwps.Count > 0);
            var workerInWorkPlace = wInwps[0];

            //var service = Provider.GetService<IStep<IProductSupplyRequest>>();
            //Assert.IsTrue(service != null, "service != null");
            //RequestSupplyViewModel req = MockRequestSupplyViewModel("EPI1", userMocked, workerInWorkPlace.WorkPlace.Code, workerInWorkPlace.DateStart.AddDays(100));
            //var reqModel = Mappers.Get(req);

            //var result = service.Execute(reqModel);
            //Assert.IsTrue(result != null, "result != null");
            //Assert.IsTrue(result.ComputeResult().IsOk(), result.Message());
            //Assert.IsTrue(reqModel.ProductSupplied != null, "ProductSupplied != null");
            //Assert.IsTrue(reqModel.ProductSupplied.Id > 0, "ProductSupplied.Id");
            //Assert.IsTrue(reqModel.ProductSupplied.Id == reqModel.ProductSuppliedId, "ProductSupplied.Id == reqModel.IdProductSupplied");
            //Assert.IsTrue(reqModel.ProductSupplied.ProductSupplyId == reqModel.WorkerInWorkPlaceId, "ProductSupplied.IdProductSupply == reqModel.IdWorkerInWorkPlace");

            //Assert.IsTrue(reqModel.ProductSupplied.ProductStock.BookingId == reqModel.WorkerInWorkPlaceId, "ProductSupplied.ProductStock.IdBooking == reqModel.IdWorkerInWorkPlace");
        }


        [TestMethod]
        public void TestProductSupplyService_IsWorkingProperly_for_Package()
        {
            Reset();

            IPeriodConfigurationService serviceConfPer = Provider.GetService<IPeriodConfigurationService>();
            IWorkerInWorkPlaceService workerService = Provider.GetService<IWorkerInWorkPlaceService>();

            var wInwps = workerService.GetWorkPlaceWhereWorkedTheWorker(workerMocked, null);
            Assert.IsTrue(wInwps.Count > 0);
            var workerInWorkPlace = wInwps[0];

            //var service = Provider.GetService<IStep<IProductSupplyRequest>>();
            //RequestSupplyViewModel req = MockRequestSupplyViewModel("EPI5", userMocked, workerInWorkPlace.WorkPlace.Code, workerInWorkPlace.DateStart.AddDays(100));
            //var reqModel = Mappers.Get(req);

            //var result = service.Execute(reqModel);
            //Assert.IsTrue(result != null, "result != null");
            //Assert.IsTrue(result.ComputeResult().IsOk(), result.Message());
            //Assert.IsTrue(reqModel.ProductSupplied != null, "ProductSupplied != null");
            //Assert.IsTrue(reqModel.ProductSupplied.Id > 0, "ProductSupplied.Id");
            //Assert.IsTrue(reqModel.ProductSupplied.Id == reqModel.ProductSuppliedId, "ProductSupplied.Id == reqModel.IdProductSupplied");
            //Assert.IsTrue(reqModel.ProductSupplied.ProductSupplyId == reqModel.WorkerInWorkPlaceId, "ProductSupplied.IdProductSupply == reqModel.IdWorkerInWorkPlace");

            //Assert.IsTrue(reqModel.ProductSupplied.ProductStock.BookingId == reqModel.WorkerInWorkPlaceId, "ProductSupplied.ProductStock.IdBooking == reqModel.IdWorkerInWorkPlace");
        }
    }
}
