using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupplyOfProducts.Api.Controllers.ViewModels;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using System.Threading.Tasks;

namespace SupplyOfProducts.Test.Services
{
    [TestClass]
    public class TestIConfigSupplyService : UnitTestServiceBase
    {


        [TestMethod]
        public  void TestConfigSupplyService_IsWorkingProperly()
        {
            Reset();


            var mapper = GetRepository<IMapper>();

            IPeriodConfigurationService serviceConfPer = Provider.GetService<IPeriodConfigurationService>();
            IWorkerInWorkPlaceService workerService = Provider.GetService<IWorkerInWorkPlaceService>();

            var wInwps = workerService.GetWorkPlaceWhereWorkedTheWorker(workerMocked, null);
            Assert.IsTrue(wInwps.Count > 0);
            var workerInWorkPlace = wInwps[0];

            var service = Provider.GetService<IStep<IManagementModelRequest<IConfigSupply>>>();
            var service2 = Provider.GetService<IStep<IManagementModelRequest<IConfigSupply>>>();
            var service3 = Provider.GetService<IStep<IManagementModelRequest<IConfigSupply>>>();
            var service4 = Provider.GetService<IStep<IManagementModelRequest<IConfigSupply>>>();

            ConfigSupplyViewModel req1 = MockRequestConfigViewModel("EPI1", workerMocked, workerInWorkPlace.WorkPlace.Code, workerInWorkPlace.DateStart.AddDays(100), 15);
            ConfigSupplyViewModel req2 = MockRequestConfigViewModel("EPI1", workerMocked, workerInWorkPlace.WorkPlace.Code, workerInWorkPlace.DateStart.AddDays(100), 25);
            ConfigSupplyViewModel req3 = MockRequestConfigViewModel("EPI1", workerMocked, workerInWorkPlace.WorkPlace.Code, workerInWorkPlace.DateStart.AddDays(100), 35);
            ConfigSupplyViewModel req4 = MockRequestConfigViewModel("EPI1", workerMocked, workerInWorkPlace.WorkPlace.Code, workerInWorkPlace.DateStart.AddDays(100), 45);
                                  
            var result1 = Task.Run(() =>
            {
                return service.Execute(new ManagementModelRequest<IConfigSupply>
                {
                    Item = mapper.Map<IConfigSupply>(req1),
                    Type = Operation.NEW
                });
            });

            var result2 = Task.Run(() =>
            {
                return service.Execute(new ManagementModelRequest<IConfigSupply>
                {
                    Item = mapper.Map<IConfigSupply>(req2),
                    Type = Operation.NEW
                });
            });

            //var result3 = Task.Run(() =>
            //{
            //    return service2.Execute(new ManagementModelRequest<IConfigSupply>
            //    {
            //        Item = mapper.Map<IConfigSupply>(req3),
            //        Type = Operation.NEW
            //    });
            //});

            //var result4 = Task.Run(() =>
            //{
            //    return service2.Execute(new ManagementModelRequest<IConfigSupply>
            //    {
            //        Item = mapper.Map<IConfigSupply>(req4),
            //        Type = Operation.NEW
            //    });
            //});

             result1.Wait();
             result2.Wait();
             //result3.Wait();
             //result4.Wait();

            Assert.IsTrue(result1.Result.ComputeResult().IsOk(), result1.Result.Message());
            Assert.IsTrue(result2.Result.ComputeResult().IsOk(), result2.Result.Message());
            //Assert.IsTrue(result3.Result.ComputeResult().IsOk(), result3.Result.Message());
            //Assert.IsTrue(result4.Result.ComputeResult().IsOk(), result4.Result.Message());
            //Assert.IsTrue(result != null, "result != null");
            //Assert.IsTrue(result.ComputeResult().IsOk(), result.Message());
            //Assert.IsTrue(reqModel.SupplyScheduled != null, "SupplyScheduled != null");
            //Assert.IsTrue(reqModel.SupplyScheduled.Id > 0, "SupplyScheduled.Id");
            //Assert.IsTrue(reqModel.SupplyScheduled.Amount == req.Amount, "SupplyScheduled.Amount == req.Amount");

        }



    }
}
