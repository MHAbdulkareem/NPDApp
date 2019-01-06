using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPDApp.DataAccess;

namespace NPDApp.Controllers
{
    public class DataAccessImpl : IDataAccess
    {
        protected NDPAppContext context;
        protected RepositoryFactory repositoryFactory;

        public DataAccessImpl()
        {
            connect();
        }
        public void connect()
        {
            context = new NDPAppContext();
            repositoryFactory = new RepositoryFactory(context);
        }
    }
}
