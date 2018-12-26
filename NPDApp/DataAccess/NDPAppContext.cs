using NPDApp.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace NPDApp.DataAccess
{
    public class NDPAppContext : DbContext
    {
        public NDPAppContext()
           : base("NDPAppContext")
        {
        }
        public DbSet<Client> Clients {get; set;}
        public DbSet<Staff> Staff {get; set;}
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Timeline> Timelines { get; set; }
        public DbSet<Machine> Machines { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

    }
}
