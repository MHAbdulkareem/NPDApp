using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPDApp.models
{
    public enum JobUrgency
    {
        [Description("Non Urgent ~ 90 Days")]
        NU0 = 90,
        [Description("Machine Working ~ 40 Days")]
        NU1 = 40,
        [Description("Machine Broken ~ 14 Days")]
        UR2 = 14,
        [Description("Machine Broken ~ 7 Days")]
        UR3 = 7,
        [Description("Machine Broken ~ 3 Days")]
        UR4 = 3,
        [Description("Machine Broken ~ 1 Day")]
        UR5 = 1
    }

    public enum JobStatus
    {
        NEW,
        PENDING,
        ACTIVE,
        INACTIVE,
        DELAYED,
        REMOTE_SOLUTION,
        CLOSED
    }

    public class Job
    {
        public Job()
        {
            this.Timelines = new List<Timeline>();
        }
        [Key]
        public int ID { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Description { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime LoggedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public JobUrgency Urgency { get; set; }

        public int ClientID { get; set; }
        [ForeignKey("ClientID")]
        public virtual Client Client { get; set; }

        public int MachineID { get; set; }
        [ForeignKey("MachineID")]
        public virtual Machine Machine { get; set; }

        public virtual ICollection<Timeline> Timelines { get; set; }
    }
}
