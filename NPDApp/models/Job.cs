using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPDApp.models
{
    public enum JobUrgency
    {
        NU0 = 90, NU1 = 40, NU2 = 40, UR2 = 14, UR3 = 7, UR4 = 3, UR5 = 1
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

        public override string ToString()
        {
            return $"Id:{ID}, Location:{Location}, Description:{Description}, LoggedDate:{LoggedDate}";
        }
    }
}
