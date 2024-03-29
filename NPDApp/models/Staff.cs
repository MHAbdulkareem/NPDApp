﻿using System;
using System.Collections.Generic;
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
    public class Staff
    {
        public Staff()
        {
            Jobs = new List<Job>();
        }
        [Key]
        public int ID { get; set; }
        
        [Required, StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters.")]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required, StringLength(50, MinimumLength = 1)]
        public string Role { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
