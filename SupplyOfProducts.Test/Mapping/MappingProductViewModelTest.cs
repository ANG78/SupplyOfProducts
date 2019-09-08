using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupplyOfProducts.Api.Controllers.ViewModels;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SupplyOfProducts.Test.Mapping
{
    [TestClass]
    public class MappingProductViewModelTest : UnitTestMappingBase
    {
        [TestMethod]
        public void MappingProduct_IsWorkingProperly()
        {
            var dateAux = DateTime.Now;
            ProductViewModel req = new ProductViewModel
            {
                Code = "Code",
                Type = "Type"
            };

            var mapper = GetRepository<IMapper>();

            var reqModel = mapper.Map<IProduct>(req);
            Assert.IsTrue(reqModel is IProduct);
            Assert.IsTrue(reqModel?.Code == req.Code);
            Assert.IsTrue(reqModel?.Type == req.Type);
            
        }

        [TestMethod]
        public void MappingProductClassEmpty_IsWorkingProperly()
        {
            ProductViewModel req = new ProductViewModel
            {
              
                Code = "Code",
                Type = "Type"
            };

            var mapper = GetRepository<IMapper>();

            var reqModel = mapper.Map<IProduct>(req);
            Assert.IsTrue(reqModel is IProduct);
            Assert.IsTrue(reqModel?.Code == req.Code);
            Assert.IsTrue(reqModel?.Type == req.Type);


        }

        [TestMethod]
        public void MappingPackage_IsWorkingProperly()
        {
            string pack = "Pack";
            string prod1 = "Prod1";
            string prod2 = "Prod2";

            var req = new ProductComplexViewModel
            {
            
                Code = pack,
                Type = "Type0",
                Parts = new List<ProductViewModel>
                {
                    new ProductViewModel
                    {
               
                        Code = prod1,
                        Type = "Type1",
                    },
                    new ProductViewModel
                    {
                
                        Code = prod2,
                        Type = "Type2",
                    },

                }
                
            };

            var mapper = GetRepository<IMapper>();

            var reqModel = mapper.Map<IProduct>(req);
            Assert.IsTrue(reqModel is IPackage);

            IPackage reqPackage = (IPackage)reqModel;

            Assert.IsTrue(reqPackage?.Code == req.Code);
            Assert.IsTrue(reqPackage?.Type == req.Type);
            Assert.IsTrue(reqPackage?.Parts.ToList().Count == 2);
            Assert.IsTrue(reqPackage?.Parts.ToList()[0].Code == prod1);
            Assert.IsTrue(reqPackage?.Parts.ToList()[1].Code == prod2);
        }



        [TestMethod]
        public void MappingWorker_IsWorkingProperly()
        {
            WorkerViewModel req = new WorkerViewModel
            {
                Code = "Code"
            };

            var mapper = GetRepository<IMapper>();

            var reqModel = mapper.Map<IWorker>(req);
            Assert.IsTrue(reqModel is IWorker);
            Assert.IsTrue(reqModel?.Code == req.Code);
            

        }
    }


}



