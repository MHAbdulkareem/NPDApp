using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPDApp.models;
using NPDApp.DataAccess;
using NPDApp.controllers;
using System.Collections.Generic;
using System.Linq;

namespace NPDAppTesting
{
    [TestClass]
    public class JobManagerTest : BaseTest
    {
       
        private JobScheduler jobScheduler;
        private IRepository<Job> jobRepository;

        [TestInitialize]
        public void SetUp()
        {
            // Populate the context with clients
            MockContext.ClientDataInitialiser = new List<Client>
            {
                new Client {ID = 1, Name = "Johnson Corporation", Address = "138  East Street, MANOROWEN, SA65 2UZ", PhoneNumber = "07865172169"},
                new Client {ID = 2, Name = "AvaRParson", Address = "120  Bury Rd, HALVERGATE, NR13 4WG", PhoneNumber = "07885388159"},
                new Client {ID = 3, Name = "JaniceTMetheny", Address = "106  Wrexham Rd, EYTON, HR6 9UJ", PhoneNumber = "07983556413"},
                new Client {ID = 4, Name = "Ruecker-Gislason", Address = "68  Lamphey Road, THE EAVES, GL15 7TE", PhoneNumber = "07847975874"},
                new Client {ID = 5, Name = "Iselectrics", Address = "16  Mill Lane, CORPUSTY, NR11 7HJ", PhoneNumber = "07702466646"}
            };

            base.SetUp();
            
            // Get the job repository from the factory
            jobRepository = repoFactory.JobRepository;

            // Create a job schedular
            jobScheduler = new JobScheduler(mockContext.Context);
        }

        [TestMethod]
        public void TestRegisterJobForAClient()
        {
            // Get the first client from the mock data
            var client = repoFactory.ClientRepository.GetByID(1);
            var machine = GetTestMachine(); // get a random machine
            
            // Schedule a new job
            jobScheduler.Description = "faulty";
            jobScheduler.Location = "66 Duckpit Lane, UPSETTLINGTON, TD15 3RS";
            jobScheduler.Client = client;
            jobScheduler.Machine = machine;
            jobScheduler.Urgency = JobUrgency.NU1;
            jobScheduler.Schedule();

            // Get the recent logged job
            var loggedJob = jobScheduler.GetLatestJob();

            // Check if the client has 
            Assert.IsTrue(client.Jobs.Where(j => j.ID == loggedJob.ID).First() != null);
        }

        private Machine GetTestMachine()
        {
            var machine = new Machine
            {
                ID = 1,
                Name = "Echelon",
                Manufacturer = "Hammock",
                Type = MachineType.LHC54
            };

            return machine;
        }

        private Client GetTestClient()
        {
            var client = new Client
            {
                ID = 1,
                Name = "Rogers",
                Address = "99  Hendford Hill, MOSELDEN HEIGHT, HD3 6GL",
                PhoneNumber = "07957235734",
                Email = "g4qe19maxg5@thrubay.com"
            };

            return client;
        }
    }
}
