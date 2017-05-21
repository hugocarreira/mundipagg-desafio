using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Mundipagg.API.Controllers;

namespace Mundipagg.API.Tests.Controllers
{
    [TestClass]
    public class PessoaControllerTests
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


            PessoaController pessoaController = this.CreatePessoaController();


        }

        private PessoaController CreatePessoaController()
        {
            return new PessoaController();
        }
    }
}