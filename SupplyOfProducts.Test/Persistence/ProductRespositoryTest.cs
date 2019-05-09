using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupplyOfProducts.Interfaces.Repository;



namespace SupplyOfProducts.Test.Persistence
{

    [TestClass]
    public class ProductRespositoryTest : UnitTestBase
    {

        [TestMethod]
        public void TestGetProductByCode()
        {
            var _productRepository = GetRepository<IProductRepository>();
            var prod = _productRepository.Get("EPI1");
            Assert.IsNotNull(prod);
   

        }
        
    }


}
