using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPDApp.models
{
    public class Address
    {
        [Key]
        public int ID { get; set; }
        public String NumberOrName { get; set; }
        public String Street { get; set; }
        public String Town { get; set; }
        public String PostCode { get; set; }
    }

}
