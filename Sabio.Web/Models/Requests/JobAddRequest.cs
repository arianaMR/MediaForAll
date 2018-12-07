using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaForAll.Web.Models
{
    public class JobAddRequest
    {

        [Required]
        public string CategoryName { get; set; }

        [Required]
        public string ProductionName { get; set; }

        [Required]
        public string JobDescription { get; set; }

        [Required]
        public DateTime ProductionDate { get; set; }

        [Required]
        public string CallTime { get; set; }
        
        [Required]
        public string TimeCommitment { get; set; }

        public string Notes { get; set; }
    }
}