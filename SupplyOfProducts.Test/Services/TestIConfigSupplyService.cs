using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupplyOfProducts.Api.Controllers.ViewModels;
using SupplyOfProducts.BusinessLogic.Mappers;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;

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
            IWorkerInWorkPlaceService workerService = Provider.GetService<IWorkerInWorkPlaceService>();

            var wInwps = workerService.GetWorkPlaceWhereWorkedTheWorker(userMocked, null);
            Assert.IsTrue(wInwps.Count > 0);
            var workerInWorkPlace = wInwps[0];

            var service = Provider.GetService<IStep<IConfigSupplyRequest>>();
            RequestConfigSupplyViewModel req = MockRequestConfigViewModel("EPI1", userMocked, workerInWorkPlace.WorkPlace.Code, workerInWorkPlace.DateStart.AddDays(100), 5);
            var reqModel = Mappers.Get(req);

            var result = service.Execute(reqModel);
            Assert.IsTrue(result != null, "result != null");
            Assert.IsTrue(result.ComputeResult().IsOk(), result.Message());
            Assert.IsTrue(reqModel.SupplyScheduled != null, "SupplyScheduled != null");
            Assert.IsTrue(reqModel.SupplyScheduled.Id > 0, "SupplyScheduled.Id");
            Assert.IsTrue(reqModel.SupplyScheduled.Amount == req.Amount, "SupplyScheduled.Amount == req.Amount");

        }



    }
}
