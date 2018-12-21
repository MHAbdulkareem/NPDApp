using NPDApp.DataAccess;
using NPDApp.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPDApp.controllers
{
    public class ClientManager
    {
        private IClientRepository clientRepository;
        public ClientManager()
        {
            clientRepository = new ClientRepository();
        }
        public ClientManager(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public List<Client> Clients
        {
            get { return clientRepository.GetClients().ToList(); }
        }

        public void AddClient(string name, string address, string phoneNumber, string email)
        {
            var newClient = new Client();
            newClient.Name = name;
            newClient.Address = address;
            newClient.PhoneNumber = phoneNumber;
            newClient.Email = email;

            clientRepository.InsertClient(newClient);
        }

        public Client GetClient(int id)
        {
            var foundClient = clientRepository.GetClients().Where(c => c.ClientID == id).FirstOrDefault();

            return foundClient;
        }

        public void RemoveClient(int id)
        {
            clientRepository.DeleteClient(id);
        }
    }
}
