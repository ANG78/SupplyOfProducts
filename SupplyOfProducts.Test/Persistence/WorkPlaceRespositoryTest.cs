using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupplyOfProducts.Interfaces.Repository;


namespace SupplyOfProducts.Test.Persistence
{
    [TestClass]
    public class WorkPlaceRespositoryTest : UnitTestBase
    {

        [TestMethod]
        public void TestGetWorkPlaceByCode_isWorkingProperly()
        {
            var _productRepository = GetRepository<IWorkPlaceRepository>();
            var prod = _productRepository.Get("WP01");
            Assert.IsNotNull(prod);

        }

    }
}
