using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPDApp.models;

namespace NPDApp.DataAccess
{
    interface IJobRepository
    {
        IEnumerable<Job> GetJobs();
        Job GetJobByID(int jobID);
        void InsertJob(Job job);
        void DeleteJob(int jobID);
        void UpdateJob(Job job);
        void save();

    }
}
