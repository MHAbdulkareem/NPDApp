using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPDApp.models
{
    public class Staff
    {
        [Key]
        public int ID { get; set; }
        
        [Required, StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters.")]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required, StringLength(50, MinimumLength = 1)]
        public string Role { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
