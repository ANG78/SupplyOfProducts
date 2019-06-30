using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using System;

namespace SupplyOfProducts.Test.Services
{

    [TestClass]
    public class TestPeriodConfigurationService : UnitTestServiceBase
    {
        
        [TestMethod]
        public void TestPeriodConfigurationService_working()
        {
            Reset();

            IWorkerInWorkPlaceService workerService = Provider.GetService<IWorkerInWorkPlaceService>();
            var currentDate = DateTime.Now;

            var wks = workerService.GetWorkPlaceWhereWorkedTheWorker(workerMocked, currentDate);
            Assert.IsTrue(wks.Count > 0, "wks.Count > 0");
            foreach (var it in wks)
            {
                Assert.IsTrue(it.DateStart < DateTime.Now, "DateStart < DateTime.Now");
                Assert.IsTrue(!it.DateEnd.HasValue || it.DateEnd.Value > currentDate, "DateFinish.HasValue || it.DateFinish.Value >  DateTime.Now");
                Assert.IsTrue(it.NumYearsByPeriod > 0, "NumYearsByPeriod > 0");
            }
            
        }

       
       
    }
}
