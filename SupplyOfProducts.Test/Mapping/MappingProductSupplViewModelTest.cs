using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupplyOfProducts.Api.Controllers.ViewModels;
using SupplyOfProducts.Interfaces.BusinessLogic;
using System;


namespace SupplyOfProducts.Test.Mapping
{
    [TestClass]
    public class MappingProductSupplViewModelTest : UnitTestMappingBase
    {
        [TestMethod]
        public void Mapping_IsWorkingProperly()
        {
            var dateAux = DateTime.Now;
            ProductSupplyViewModel req = MockProductSupplyViewModel(produceMocked, workerMocked, workPlaceMocked, dateAux, 10);

            var mapper = GetRepository<IMapper>();

            var reqModel = mapper.Map<IProductSupply>(req);
            Assert.IsTrue(reqModel?.WorkerInWorkPlace.Worker != null);
            Assert.IsTrue(reqModel?.WorkerInWorkPlace.Worker.Code == req.WorkerCode);
            Assert.IsTrue(reqModel?.WorkerInWorkPlace.WorkPlace != null);
            Assert.IsTrue(reqModel?.WorkerInWorkPlace.WorkPlace.Code == req.WorkPlaceCode);
            Assert.IsTrue(reqModel?.Product != null && reqModel.Product.Code == req.ProductCode);
            Assert.IsTrue(reqModel?.Date == req.Date);


        }
    }


}



