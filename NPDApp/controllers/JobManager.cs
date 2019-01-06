#define TEST
using NPDApp.Controllers;
using NPDApp.DataAccess;
using NPDApp.models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NPDApp.controllers
{
    public class JobManager
    {
        private IRepository<Job> jobRepository;
        private List<Job> registeredJobs;
        private Job aJob;

        public JobManager(IRepository<Job> repository)
        {
            // Get the job repository from the repository factory
            jobRepository = repository;
            RetrieveRegisteredJobs();
        }

        public void RetrieveRegisteredJobs()
        {
            registeredJobs = (from jobs in jobRepository.Get()
                             select jobs).ToList();
            Schedule();
        }

        // Return the list of all jobs
        public List<Job> RegisteredJobs { get { return registeredJobs; } }

        // Properties to set up the new job
        public string Description { get; set; }
        public string Location { get; set; }
        public JobUrgency Urgency { get; set; }
        public int Client { get; set; }
        public int Machine { get; set; }

        // Schedule a new job
        public void Register()
        {
            // Make sure the data is not empty
            if (Description.Trim().Length > 0 && Location.Trim().Length > 0)
            {
                // Make sure the required data is provided
                if (Client > 0 && Machine > 0)
                {
                    // Create a new job
                    aJob = new Job
                    {
                        Description = Description,
                        Location = Location,
                        LoggedDate = DateTime.Now,
                        EndDate = null,
                        Urgency = Urgency,
                        ClientID = Client,
                        MachineID = Machine
                    };

                    // Estimate the start date based on the urgency
                    ComputeStartDate();

                    // Register the job under a client and save to DB
                    jobRepository.Insert(aJob);

                    //Retrieve updated jobs list and reset scheduling parameters
                    RetrieveRegisteredJobs();
                    ResetProperties();

                    return;
                }
            }

            // Something went wrong
            throw new Exception("The job cannot be registered.");
        }

        private void ResetProperties()
        {
            Description = string.Empty;
            Location = string.Empty;
            Client = 0;
            Machine = 0;
        }

        public Job GetLatestJob()
        {
            // If there is no recently logged job
            if (aJob == null)
            {
                // Get the last logged job
                aJob = (from job in jobRepository.Get()
                        orderby job.LoggedDate
                        select job).Last() as Job;
            }

            // Return latest job
            return aJob;
        }

        private void Schedule()
        {
            if (registeredJobs != null)
                registeredJobs.Sort(new JobScheduler());
        }

        private void ComputeStartDate()
        {
            // Switch through the JobUrgency type and calcualte the start date
            switch(aJob.Urgency)
            {
                case JobUrgency.NU0:
                default:
                    aJob.StartDate = aJob.LoggedDate.AddDays((int)JobUrgency.NU0);
                    break;
                case JobUrgency.NU1:
                    aJob.StartDate = aJob.LoggedDate.AddDays((int)JobUrgency.NU1);
                    break;
                case JobUrgency.UR2:
                    aJob.StartDate = aJob.LoggedDate.AddDays((int)JobUrgency.UR2);
                    break;
                case JobUrgency.UR3:
                    aJob.StartDate = aJob.LoggedDate.AddDays((int)JobUrgency.UR3);
                    break;
                case JobUrgency.UR4:
                    aJob.StartDate = aJob.LoggedDate.AddDays((int)JobUrgency.UR4);
                    break;
                case JobUrgency.UR5:
                    aJob.StartDate = aJob.LoggedDate.AddDays((int)JobUrgency.UR5);
                    break;
            }
        }

        public void UpdateSchedule(Job aJob, DateTime newDate)
        {
            var jobToUpdate = jobRepository.SearchFor(j => j.ID == aJob.ID && j.Urgency == aJob.Urgency).First();

            if(jobToUpdate != null)
            {
                jobToUpdate.StartDate = newDate;
            }

            jobRepository.Update(jobToUpdate);
            Schedule();
        }

        private class JobScheduler : IComparer<Job>
        {
            public int Compare(Job x, Job y)
            {
                // Get the days remaining to commence both jobs
                int xDaysToStart = (x.StartDate - DateTime.Now).Days;
                int yDaysToStart = (y.StartDate - DateTime.Now).Days;

                // Give priority to the job with the less number of days
                if (xDaysToStart > yDaysToStart)
                    return 1;
                if (xDaysToStart < yDaysToStart)
                    return -1;
                else
                    return 0;
            }
        }
    }
}