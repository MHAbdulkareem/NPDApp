using NPDApp.DataAccess;
using NPDApp.models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NPDApp.controllers
{
    public class JobScheduler
    {
        // 
        RepositoryFactory repoFactory;
        private IRepository<Job> jobRepository;
        private Job aJob;

        public JobScheduler(NDPAppContext context)
        {
            // Initialise the factory with the givent context
            repoFactory = new RepositoryFactory(context);
            // Get the job repository from the repository factory
            jobRepository = repoFactory.JobRepository;
        }

        // Return the list of all jobs
        public List<Job> ScheduledJobs
        {
            get { return jobRepository.Get() as List<Job>; }
        }

        // Properties to set up the new job
        public string Description { get; set; }
        public string Location { get; set; }
        public JobUrgency Urgency { get; set; }
        public Client Client { get; set; }
        public Machine Machine { get; set; }

        // Schedule a new job
        public void Schedule()
        {
            // Make sure the data is not empty
            if (Description.Trim().Length > 0 && Location.Trim().Length > 0)
            {
                // Make sure the required data is provided
                if (Client != null && Machine != null)
                {
                    // Create a new job
                    aJob = new Job
                    {
                        Description = Description,
                        Location = Location,
                        LoggedDate = DateTime.Now,
                        Urgency = Urgency,
                        Client = Client,
                        Machine = Machine
                    };

                    // Estimate the start date based on the urgency
                    ComputeStartDate();

                    // Register the job under a client
                    Client.Jobs.Add(aJob);
                    return;
                }
            }

            // Something went wrong
            throw new Exception("The job cannot be registered.");
            
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
    }
}