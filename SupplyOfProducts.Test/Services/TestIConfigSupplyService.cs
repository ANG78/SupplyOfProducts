using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupplyOfProducts.Api.Controllers.ViewModels;
using SupplyOfProducts.BusinessLogic.Mappers;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;

namespace SupplyOfProducts.Test.Services
{
    [TestClass]
    public class TestIConfigSupplyService : UnitTestBase
    {

        [TestMethod]
        public void TestConfigSupplyService_IsWorkingProperly()
        {
            Reset();

            IPeriodConfigurationService serviceConfPer = Provider.GetService<IPeriodConfigurationService>();
            IWorkerService workerService = Provider.GetService<IWorkerService>();

            var wInwps = workerService.GetWorkPlaceWhereWorkedTheWorker(userMocked, null);
            Assert.IsTrue(wInwps.Count > 0);
            var workerInWorkPlace = wInwps[0];

            var service = Provider.GetService<IStep<IConfigSupply>>();
            RequestConfigSupplyViewModel req = MockRequestConfigViewModel("EPI1", userMocked, workerInWorkPlace.WorkPlace.Code, workerInWorkPlace.DateStart.AddDays(100), 5);
            var reqModel = Mappers.Get(req);

            var result = service.Execute(reqModel);
            Assert.IsTrue(result != null, "result != null");
            Assert.IsTrue(result.ComputeResult().IsOk(), result.Message());
            Assert.IsTrue(reqModel.Result != null, "Result != null");
            Assert.IsTrue(reqModel.Result.Id > 0, "Result.Id");
            Assert.IsTrue(reqModel.Result.Amount == req.Amount, "Result.Amount == req.Amount");

        }



    }
}
