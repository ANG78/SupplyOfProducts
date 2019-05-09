using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupplyOfProducts.Interfaces.Repository;

namespace SupplyOfProducts.Test.Persistence
{
    [TestClass]
    public class ProductStockRespositoryTest : UnitTestBase
    {

        [TestMethod]
        public void TestGetSupplyScheduledByCode_isWorkingProperly()
        {
            var _productRepository = GetRepository<IProductStockRepository>();
            var res = _productRepository.Get("EPI1-001");
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Product);

        }

    }
}
