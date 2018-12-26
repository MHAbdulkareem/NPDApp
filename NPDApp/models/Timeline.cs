using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPDApp.models
{
    public class Timeline
    {
        [Key]
        public int ID { get; set; }

        public int JobID { get; set; }

        public DateTime Date { get; set; }

        public string Outcome { get; set; }

        [ForeignKey("JobID")]
        public virtual Job Job { get; set; }
    }
}
