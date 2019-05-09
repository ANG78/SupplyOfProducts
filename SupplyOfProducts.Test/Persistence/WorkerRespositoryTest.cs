using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupplyOfProducts.Interfaces.Repository;

namespace SupplyOfProducts.Test.Persistence
{
    [TestClass]
    public class WorkerRespositoryTest : UnitTestBase
    {

        [TestMethod]
        public void TestGetWorkerByCode_isWorkingProperly()
        {
            var _productRepository = GetRepository<IWorkerRepository>();
            var prod = _productRepository.Get("W01");
            Assert.IsNotNull(prod);
        }

    }
}
