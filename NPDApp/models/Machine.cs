using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * TEAM MEMBERS
 * AMINU ABDULMALIK (16040781)
 * MUHAMMAD HUSSAINI (17045588)
 */
namespace NPDApp.models
{
    public enum MachineType
    {
        [Description("Small, Low Complexity")]
        STL0,
        [Description("Complex, Table Top")]
        STC1,
        [Description("Medium Size and Complexity")]
        MMC2,
        [Description("Medium Size, High Complexity")]
        MHC3,
        [Description("Large, Low Complexity")]
        LLC4,
        [Description("Large, High Complexity")]
        LHC5
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

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
