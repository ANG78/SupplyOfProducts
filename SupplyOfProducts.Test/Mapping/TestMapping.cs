using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupplyOfProducts.Api.Controllers.ViewModels;
using SupplyOfProducts.BusinessLogic.Mappers;
using System;


namespace SupplyOfProducts.Test.Mapping
{
    [TestClass]
    public class TestMapping : UnitTestBase
    {
        
        [TestMethod]
        public void TestMappingRequestSupplyViewModel()
        {
            RequestSupplyViewModel req = MockRequestSupplyViewModel("EPI1", this.userMocked, "WP01", DateTime.Now);
            var reqModel = Mappers.Get(req);
            Assert.IsTrue(reqModel != null && reqModel.WorkerInWorkPlace.Worker != null);
            Assert.IsTrue(reqModel.WorkerInWorkPlace.Worker.Code == req.CodeWorker);
            Assert.IsTrue(reqModel != null && reqModel.Product != null && reqModel.Product.Code == req.CodeProduct);
            Assert.IsTrue(reqModel != null && reqModel.Date.Day == DateTime.Now.Day);

        }

      


    }

    
}
