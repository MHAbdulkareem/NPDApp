using NPDApp.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPDApp.DataAccess
{
    public class RepositoryFactory : IDisposable
    {
        // use a single context for all model repository to enforce transaction
        // using UnitOfWork pattern
        private readonly NDPAppContext _context;
        // declare repository instances for the models
        private GenericRepository<Client> clientRepository;
        private GenericRepository<Machine> machineRepository;
        private GenericRepository<Staff> staffRepository;
        private GenericRepository<Job> jobRepository;
        private GenericRepository<Timeline> timelineRepository;

        // use the provided database context to allow unit test with a mock context
        public RepositoryFactory(NDPAppContext context)
        {
            _context = context;
        }

        // prevent multiple instances of repsitories to prevent database conflict
        public GenericRepository<Client> ClientRepository
        {
            get
            {
                // prevent creation of multiple instance of the repository
                if (clientRepository == null)
                    clientRepository = new GenericRepository<Client>(_context);
                return clientRepository;
            }
        }

        // Factory property for staff repository
        public GenericRepository<Staff> StaffRepository
        {
            get
            {
                // prevent creation of multiple instance of the repository
                if (staffRepository == null)
                    staffRepository = new GenericRepository<Staff>(_context);
                return staffRepository;
            }
        }

        // Factory property for machine repository
        public GenericRepository<Machine> MachineRepository
        {
            get
            {
                // prevent creation of multiple instance of the repository
                if (machineRepository == null)
                    machineRepository = new GenericRepository<Machine>(_context);
                return machineRepository;
            }
        }

        // Factory property for job repository
        public GenericRepository<Job> JobRepository
        {
            get
            {
                // prevent creation of multiple instance of the repository
                if (jobRepository == null)
                    jobRepository = new GenericRepository<Job>(_context);
                return jobRepository;
            }
        }

        // Factory property for timeline repository
        public GenericRepository<Timeline> TimelineRepository
        {
            get
            {
                // prevent creation of multiple instance of the repository
                if (timelineRepository == null)
                    timelineRepository = new GenericRepository<Timeline>(_context);
                return timelineRepository;
            }
        }

        // save all changes to db
        // this operation is atomic 
        // whereby all changes are commited or rolled back
        public void Save()
        {
            _context.SaveChanges();
        }

        // clear all resources held by the db context
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
