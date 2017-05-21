using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Mundipagg.API.Controllers;

namespace Mundipagg.API.Tests.Controllers
{
    [TestClass]
    public class DividaControllerTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void TestMethod1()
        {


            DividaController dividaController = this.CreateDividaController();


        }

        private DividaController CreateDividaController()
        {
            return new DividaController();
        }
    }
}