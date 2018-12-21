using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPDApp.models
{

    public enum JobUrgency
    {
        NU0, NU1, NU2, UR2, UR3, UR4, UR5
    }
    class Job
    {
        [Key]
        public int JobID { get; set; }

        public int ClientID { get; set; }

        public int MachineID { get; set; }

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

        public virtual Client Client { get; set; }

        public Machine Machine { get; set; }

        public virtual ICollection<Timeline> Timelines { get; set; }
    }
}
