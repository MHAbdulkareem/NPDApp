using System;
using NPDApp.models;
using NPDApp.DataAccess;
using NPDApp.controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace NPDAppTesting
{
    [TestClass]
    public class ClientManagerTest
    {
        private ClientManager clientManager;
        [TestInitialize]
        public void SetUp()
        {
            clientManager = new ClientManager(new MockClientRepository());
        }

        [TestMethod]
        public void TestClientsWithEmptyRepository()
        {
            Assert.AreEqual(0, clientManager.Clients.Count);
        }
        
        class MockClientRepository : IClientRepository
        {
            List<Client> clients;

            public MockClientRepository()
            {
                clients = new List<Client>();
                //InitialiseList();
            }

            public void InitialiseList()
            {
                clients.AddRange(new List<Client>
                {
                    new Client {Name = "Johnson Corporation", Address = "138  East Street, MANOROWEN, SA65 2UZ", PhoneNumber = "07865172169"},
                    new Client {Name = "AvaRParson", Address = "120  Bury Rd, HALVERGATE, NR13 4WG", PhoneNumber = "07885388159"},
                    new Client {Name = "JaniceTMetheny", Address = "106  Wrexham Rd, EYTON, HR6 9UJ", PhoneNumber = "07983556413"},
                    new Client {Name = "Ruecker-Gislason", Address = "68  Lamphey Road, THE EAVES, GL15 7TE", PhoneNumber = "07847975874"},
                    new Client {Name = "Iselectrics", Address = "16  Mill Lane, CORPUSTY, NR11 7HJ", PhoneNumber = "07702466646"}
                });
            }
            public IEnumerable<Client> GetClients()
            {
                return clients;
            }

            public Client GetClientByID(int clientID)
            {
                return clients.Find(c => c.ClientID == clientID);
            }

            public void InsertClient(Client client)
            {
                clients.Add(client);
            }

            public void DeleteClient(int clientID)
            {
                var client = GetClientByID(clientID);

                clients.Remove(client);
            }

            public void UpdateClient(Client client)
            {
                var uClient = clients.Find(c => c.ClientID == client.ClientID);

                if(uClient != null)
                {
                    uClient.Name = client.Name;
                    uClient.Address = client.Address;
                    uClient.PhoneNumber = client.PhoneNumber;
                    uClient.Email = client.Email;
                }
            }

            public void save()
            {
                //
            }
        }
    }
}
