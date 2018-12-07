
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaForAll.Web.Domain
{
    public class Applicant
    {
        public int ApplicantKey { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public DateTime JoinDate { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }


        public List<Experience> Experience { get; set; }

        public List<Interest> Interest { get; set; }
    }
}