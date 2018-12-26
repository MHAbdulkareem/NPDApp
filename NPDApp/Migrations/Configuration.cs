namespace NPDApp.Migrations
{
    using NPDApp.models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NPDApp.DataAccess.NDPAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NPDApp.DataAccess.NDPAppContext context)
        {
            context.Clients.AddRange(new List<Client>()
            {
                new Client { Name = "Johnson Corporation", Address = "138  East Street, MANOROWEN, SA65 2UZ", PhoneNumber = "07865172169" },
                new Client { Name = "AvaRParson", Address = "120  Bury Rd, HALVERGATE, NR13 4WG", PhoneNumber = "07885388159" },
                new Client { Name = "JaniceTMetheny", Address = "106  Wrexham Rd, EYTON, HR6 9UJ", PhoneNumber = "07983556413" },
                new Client { Name = "Ruecker-Gislason", Address = "68  Lamphey Road, THE EAVES, GL15 7TE", PhoneNumber = "07847975874" },
                new Client { Name = "Iselectrics", Address = "16  Mill Lane, CORPUSTY, NR11 7HJ", PhoneNumber = "07702466646" }
            });

            context.SaveChanges();
        }
    }
}
