using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupplyOfProducts.Interfaces.Repository;

namespace SupplyOfProducts.Test.Persistence
{
    [TestClass]
    public class WorkerInWorkPlaceRespositoryTest : UnitTestBase
    {

        [TestMethod]
        public void TestGetWorkerInWorkPlaceByCode_isWorkingProperly()
        {
            var _productRepository = GetRepository<IWorkerInWorkPlaceRepository>();
            var res = _productRepository.GetWorkPlace("W01",null);
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Count>0);
            Assert.IsNotNull(res[0].Worker);
            Assert.IsNotNull(res[0].WorkPlace);
            
        }

    }
}
