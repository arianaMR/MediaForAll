using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaForAll.Web.Models
{
    public class PasswordUpdateRequest
    {

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}