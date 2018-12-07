
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaForAll.Web.Domain
{
    public class Credential
    {
        public int CredentialKey { get; set; }

        public int ApplicantKey { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }
    }
}