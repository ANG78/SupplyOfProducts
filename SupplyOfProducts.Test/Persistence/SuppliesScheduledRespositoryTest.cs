using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupplyOfProducts.Interfaces.Repository;

namespace SupplyOfProducts.Test.Persistence
{
    [TestClass]
    public class SuppliesScheduledRespositoryTest : UnitTestBase
    {

        [TestMethod]
        public void TestGetSuppliesScheduledtoWorker_isWorkingProperly()
        {
            var _productRepository = GetRepository<ISupplyScheduledRepository>();
            var result = _productRepository.Get("EPI1","W01","WP01", new System.DateTime(2010,10,10) );
            Assert.IsNotNull(result);
            Assert.IsNotNull(result?.WorkerInWorkPlace?.Worker);
            Assert.IsNotNull(result?.WorkerInWorkPlace?.WorkPlace);
        }

    }
}
