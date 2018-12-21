using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPDApp.models
{
    class Timeline
    {
        [Key]
        public int TimelineID { get; set; }

        public int JobID { get; set; }

        public DateTime Date { get; set; }

        public string Outcome { get; set; }

        public virtual Job Job { get; set; }
    }
}
