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
        public string NumberOrName { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }
    }

}
