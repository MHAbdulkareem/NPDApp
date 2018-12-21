using NPDApp.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPDApp.DataAccess
{
    interface IStaffRepository
    {
        IEnumerable<Staff> GetJobs();
        Staff GetJobByID(int staffID);
        void InsertJob(Staff staff);
        void DeleteJob(int staffID);
        void UpdateJob(Staff job);
        void save();

    }
}
