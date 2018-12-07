using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaForAll.Web.Models
{
    public class ApplicationAddRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        
        [Required]
        public bool IsAdmin { get; set; }

        public ExperienceAddRequest[] Experience { get; set; }

        public InterestAddRequest[] Interest { get; set; }
    }
}