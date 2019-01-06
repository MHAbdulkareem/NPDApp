using NPDApp.models;
using NPDApp.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using NPDApp.controllers;

namespace NPDAppTesting
{
    [TestClass]
    public class ClientManagerTest : BaseTest
    {
        private IRepository<Client> clientRepository;
        private ClientManager clientManager;

        [TestInitialize]
        public void SetUp()
        {
            base.SetUp();
            clientManager = new ClientManager();
            clientRepository = repoFactory.ClientRepository;

        }

        [TestMethod]
        public void TestClientsWithEmptyRepository()
        {
            Assert.AreNotEqual(0, clientRepository.Get().Count());
        }

        [TestMethod]
        public void TestAddClient()
        {
            // Get the total number of clients before insertion
            int currentNumberOfClients = clientRepository.Get().Count();

            // Create a new client
            var newClient = new Client
            {
                Name = "Robertson Stephens",
                Address = "74  Whitby Road, DENWICK, NE66 5QP",
                PhoneNumber = "07016231506",
                Email = "qdojzqeppqf@iffymedia.com"
            };

            // Add the new client to the repository
            clientRepository.Insert(newClient);

            // check if the total client count has increased 
            Assert.AreEqual(currentNumberOfClients + 1, clientRepository.Get().Count());
        }
    }
}
