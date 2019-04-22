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
    public class TestPeriodConfigurationService : UnitTestBase
    {
        
        [TestMethod]
        public void TestPeriodConfigurationService_working()
        {
            Reset();

            IWorkerService workerService = Provider.GetService<IWorkerService>();
            var currentDate = DateTime.Now;

            var wks = workerService.GetWorkPlaceWhereWorkedTheWorker(userMocked, currentDate);
            Assert.IsTrue(wks.Count > 0, "wks.Count > 0");
            foreach (var it in wks)
            {
                Assert.IsTrue(it.DateStart < DateTime.Now, "DateStart < DateTime.Now");
                Assert.IsTrue(!it.DateFinish.HasValue || it.DateFinish.Value > currentDate, "DateFinish.HasValue || it.DateFinish.Value >  DateTime.Now");
                Assert.IsTrue(it.NumYearsByPeriod > 0, "NumYearsByPeriod > 0");
            }
            
        }

       
       
    }
}
