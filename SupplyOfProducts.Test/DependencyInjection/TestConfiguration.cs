using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace SupplyOfProducts.Test
{
    [TestClass]
    public class TestConfiguration : UnitTestBase
    {
        [TestMethod]
        public void TestConfigurationIoC()
        {
            var serviceMemory = Provider.GetService<IMapper>();
            Assert.IsNotNull(serviceMemory);


        }

    }
}
