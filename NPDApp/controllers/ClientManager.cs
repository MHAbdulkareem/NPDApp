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
        private IClientRepository _clientRepository;

        public ClientManager()
        {
            _clientRepository = new ClientRepository();
        }
        public ClientManager(IClientRepository clientRepository)
        {
            this._clientRepository = clientRepository;
        }

        public List<Client> Clients
        {
            get { return _clientRepository.GetClients().ToList(); }
        }

        public void AddClient(string name, string address, string phoneNumber, string email)
        {
            var newClient = new Client
            {
                Name = name,
                Address = address,
                PhoneNumber = phoneNumber,
                Email = email
            };

            _clientRepository.InsertClient(newClient);
        }

        public Client GetClient(int id)
        {
            var foundClient = _clientRepository.GetClients().Where(c => c.ID == id).FirstOrDefault();

            return foundClient;
        }

        public void RemoveClient(Client client)
        {
            _clientRepository.DeleteClient(client.ID);
        }
    }
}
