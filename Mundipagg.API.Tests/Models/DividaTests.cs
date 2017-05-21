using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Mundipagg.API.Models;

namespace Mundipagg.API.Tests.Models
{
    [TestClass]
    public class DividaTests
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


            Divida divida = this.CreateDivida();


        }

        private Divida CreateDivida()
        {
            return new Divida();
        }
    }
}