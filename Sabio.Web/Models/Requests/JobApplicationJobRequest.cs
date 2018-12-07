using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaForAll.Web.Models
{
    public class JobApplicationAddRequest
    {
        [Required]
        public string ApplicantKey { get; set; }

        [Required]
        public string JobKey { get; set; }
    }
}