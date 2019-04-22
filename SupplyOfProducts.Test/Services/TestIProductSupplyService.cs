using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupplyOfProducts.Api.Controllers.ViewModels;
using SupplyOfProducts.BusinessLogic.Mappers;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using System;

namespace SupplyOfProducts.Test.Services
{
    [TestClass]
    public class TestProductSupplyService : UnitTestBase
    {
        [TestMethod]
        public void TestProductSupplyService_IsWorkingProperly()
        {
            Reset();

            IPeriodConfigurationService serviceConfPer = Provider.GetService<IPeriodConfigurationService>();
            IWorkerService workerService = Provider.GetService<IWorkerService>();

            var wInwps = workerService.GetWorkPlaceWhereWorkedTheWorker(userMocked, null);
            Assert.IsTrue(wInwps.Count > 0);
            var workerInWorkPlace = wInwps[0];

            var service = Provider.GetService<IStep<IProductSupply>>();
            RequestSupplyViewModel req = MockRequestSupplyViewModel("EPI1", userMocked, workerInWorkPlace.WorkPlace.Code, workerInWorkPlace.DateStart.AddDays(100));
            var reqModel = Mappers.Get(req);

            var result = service.Execute(reqModel);
            Assert.IsTrue(result != null, "result != null");
            Assert.IsTrue(result.ComputeResult().IsOk(), result.Message());
            Assert.IsTrue(reqModel.ProductSupplied != null, "ProductSupplied != null");
            Assert.IsTrue(reqModel.ProductSupplied.Id > 0, "ProductSupplied.Id");
            Assert.IsTrue(reqModel.ProductSupplied.Id == reqModel.IdProductSupplied, "ProductSupplied.Id == reqModel.IdProductSupplied");
            Assert.IsTrue(reqModel.ProductSupplied.IdProductSupply == reqModel.IdWorkerInWorkPlace, "ProductSupplied.IdProductSupply == reqModel.IdWorkerInWorkPlace");

            Assert.IsTrue(reqModel.ProductSupplied.ProductStock.IdBooking == reqModel.IdWorkerInWorkPlace, "ProductSupplied.ProductStock.IdBooking == reqModel.IdWorkerInWorkPlace");
        }


        [TestMethod]
        public void TestProductSupplyService_IsWorkingProperly_for_Package()
        {
            Reset();

            IPeriodConfigurationService serviceConfPer = Provider.GetService<IPeriodConfigurationService>();
            IWorkerService workerService = Provider.GetService<IWorkerService>();

            var wInwps = workerService.GetWorkPlaceWhereWorkedTheWorker(userMocked, null);
            Assert.IsTrue(wInwps.Count > 0);
            var workerInWorkPlace = wInwps[0];

            var service = Provider.GetService<IStep<IProductSupply>>();
            RequestSupplyViewModel req = MockRequestSupplyViewModel("EPI5", userMocked, workerInWorkPlace.WorkPlace.Code, workerInWorkPlace.DateStart.AddDays(100));
            var reqModel = Mappers.Get(req);

            var result = service.Execute(reqModel);
            Assert.IsTrue(result != null, "result != null");
            Assert.IsTrue(result.ComputeResult().IsOk(), result.Message());
            Assert.IsTrue(reqModel.ProductSupplied != null, "ProductSupplied != null");
            Assert.IsTrue(reqModel.ProductSupplied.Id > 0, "ProductSupplied.Id");
            Assert.IsTrue(reqModel.ProductSupplied.Id == reqModel.IdProductSupplied, "ProductSupplied.Id == reqModel.IdProductSupplied");
            Assert.IsTrue(reqModel.ProductSupplied.IdProductSupply == reqModel.IdWorkerInWorkPlace, "ProductSupplied.IdProductSupply == reqModel.IdWorkerInWorkPlace");

            Assert.IsTrue(reqModel.ProductSupplied.ProductStock.IdBooking == reqModel.IdWorkerInWorkPlace, "ProductSupplied.ProductStock.IdBooking == reqModel.IdWorkerInWorkPlace");
        }
    }
}
