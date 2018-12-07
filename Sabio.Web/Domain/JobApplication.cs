
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaForAll.Web.Domain
{
    public class JobApplication
    {
        public int ApplicantKey { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public DateTime JoinDate { get; set; }

        public string CategoryName { get; set; }

        public int JobKey { get; set; }

        public string ProductionName { get; set; }

        public string JobDescription { get; set; }

        public DateTime ProductionDate { get; set; }

        public string CallTime { get; set; }
      
        public string TimeCommitment { get; set; }

        public string Notes { get; set; }
    }
}