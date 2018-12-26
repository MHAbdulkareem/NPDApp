using NPDApp.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPDApp.DataAccess
{
    class ClientRepository : IClientRepository
    {
        public ClientRepository()
        {

        }

        public IEnumerable<models.Client> GetClients()
        {
            throw new NotImplementedException();
        }

        public models.Client GetClientByID(int clientID)
        {
            throw new NotImplementedException();
        }

        public void InsertClient(Client client)
        {
            throw new NotImplementedException();
        }

        public void DeleteClient(int clientID)
        {
            throw new NotImplementedException();
        }

        public void UpdateClient(Client client)
        {
            throw new NotImplementedException();
        }

        public void save()
        {
            throw new NotImplementedException();
        }
    }
}
