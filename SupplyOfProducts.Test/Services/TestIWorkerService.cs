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
    public class TestIWorkerService : UnitTestBase
    {

        [TestMethod]
        public void TestIWorkerService_working()
        {

            Reset();
            IWorkerService service = Provider.GetService<IWorkerService>();
            string codW = userMocked;
            var resWorker = service.CheckExist(codW);
            Assert.IsTrue(resWorker != null && resWorker.ComputeResult().IsOk());
            Assert.IsTrue(resWorker.GetItem().Code == codW);
        }
    }
}
