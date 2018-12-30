using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPDApp.models
{
    public class Client
    {
        public Client()
        {
            this.Jobs = new List<Job>();
        }
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [RegularExpression(@"^\(?0( *\d\)?){9,10}$")]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        /*
        [Required]
        public bool Eula { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }
        */
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
