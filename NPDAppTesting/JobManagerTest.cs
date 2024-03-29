﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPDApp.models;
using NPDApp.DataAccess;
using NPDApp.controllers;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Infrastructure;
/*
 * TEAM MEMBERS
 * AMINU ABDULMALIK (16040781)
 * MUHAMMAD HUSSAINI (17045588)
 */
namespace NPDAppTesting
{
    [TestClass]
    public class JobManagerTest : BaseTest
    {
       
        private JobManager jobManager;
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
            jobManager = new JobManager(jobRepository);
        }

        [TestMethod]
        public void TestRegisterJobForAClient()
        {
            // Get the first client from the mock data
            var client = repoFactory.ClientRepository.GetByID(1);
            var machine = GetTestMachine(); // get a random machine
            
            // Schedule a new job
            jobManager.Description = "faulty";
            jobManager.Location = "66 Duckpit Lane, UPSETTLINGTON, TD15 3RS";
            jobManager.Client = client.ID;
            jobManager.Machine = machine.ID;
            jobManager.Urgency = JobUrgency.NU1;
            jobManager.Register();

            // Get the recent logged job
            var loggedJob = jobManager.GetLatestJob();

            // Check if job is registerd to client
            Assert.AreEqual(client.ID, loggedJob.ClientID);
        
        }

        [TestMethod]
        public void TestAutomaticJobSchedule()
        {
            ScheduleJobs();

            // Schedule a new job
            jobManager.Description = "faulty";
            jobManager.Location = "66 Duckpit Lane, UPSETTLINGTON, TD15 3RS";
            jobManager.Client = 1;
            jobManager.Machine = 1;
            jobManager.Urgency = JobUrgency.UR5;
            jobManager.Register();

            // Get the last logged job
            var lastJob = jobManager.GetLatestJob();

            // Retrieve all logged job
            List<Job> rJobs = jobManager.RegisteredJobs;

            // Assert if the last job is scheduled automatically
            Assert.IsTrue(rJobs.ElementAt(0).Urgency == lastJob.Urgency);
        }

        [TestMethod]
        public void TestManualJobScheduleOverride()
        {
            ScheduleJobs();

            var lastJob = jobManager.RegisteredJobs.ElementAt(1);

            int lastJobIndex = jobManager.RegisteredJobs.FindIndex(j => j.Urgency == lastJob.Urgency);

            DateTime newDate = lastJob.StartDate.AddDays(-90);

            jobManager.UpdateSchedule(lastJob, newDate);

            int newJobIndex = jobManager.RegisteredJobs.FindIndex(j => j.Urgency == lastJob.Urgency);

            Assert.IsTrue(lastJobIndex != newJobIndex);
        }

        private void ScheduleJobs()
        {
            // Schedule a new job
            jobManager.Description = "faulty";
            jobManager.Location = "66 Duckpit Lane, UPSETTLINGTON, TD15 3RS";
            jobManager.Client = 1;
            jobManager.Machine = 1;
            jobManager.Urgency = JobUrgency.UR2;
            jobManager.Register();

            // Schedule a new job
            jobManager.Description = "Not working";
            jobManager.Location = "99  Hendford Hill, MOSELDEN HEIGHT, HD3 6GL";
            jobManager.Client = 1;
            jobManager.Machine = 1;
            jobManager.Urgency = JobUrgency.UR4;
            jobManager.Register();
        }

        private Machine GetTestMachine()
        {
            var machine = new Machine
            {
                ID = 1,
                Name = "Echelon",
                Manufacturer = "Hammock",
                Type = MachineType.LHC5
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
