using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupplyOfProducts.Persistance;


namespace SupplyOfProducts.Test
{
    [TestClass]
    public class TestConfiguration : UnitTestBase
    {
        [TestMethod]
        public void TestConfigurationIoC()
        {
            MemoryContext serviceMemory = Provider.GetService<MemoryContext>();
            Assert.IsNotNull(serviceMemory);


        }

    }
}
