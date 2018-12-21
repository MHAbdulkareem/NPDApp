using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPDApp.models;

namespace NPDApp.DataAccess
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetClients();
        Client GetClientByID(int clientID);
        void InsertClient(Client client);
        void DeleteClient(int clientID);
        void UpdateClient(Client client);
        void save();

    }
}
