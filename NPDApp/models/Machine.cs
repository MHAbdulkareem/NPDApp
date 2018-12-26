using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPDApp.models
{
    public enum MachineType
    {
        STL0, STC1, MMC2, MHC3, LLC4, LLC5, LHC54
    }
    public class Machine
    {
        public Machine()
        {
            Jobs = new List<Job>();
        }

        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        [Required]
        public MachineType Type { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
