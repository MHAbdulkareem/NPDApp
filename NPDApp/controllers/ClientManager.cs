using NPDApp.DataAccess;
using NPDApp.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * TEAM MEMBERS
 * AMINU ABDULMALIK (16040781)
 * MUHAMMAD HUSSAINI (17045588)
 */
namespace NPDApp.controllers
{
    public class ClientManager
    {
        
        private IRepository<Client> repository;
        private List<Client> registeredClients;

        public ClientManager(IRepository<Client> repository)
        {
            this.repository = repository;
            LoadRegisteredClient();
        }

        public void LoadRegisteredClient()
        {
            registeredClients = (from clients in repository.Get()
                              select clients).ToList();
        }

        public List<Client> RegisteredClients { get { return registeredClients; } }

        public void AddClient(string name, string address, string phoneNumber, string email)
        {
            var newClient = new Client
            {
                Name = name,
                Address = address,
                PhoneNumber = phoneNumber,
                Email = email
            };

            repository.Insert(newClient);
        }
        public Client GetClient(int id)
        {
            var foundClient = repository.GetByID(id);
            return foundClient;
        }
        public void RemoveClient(Client client)
        {
            repository.Delete(client);
        }
    }
}
