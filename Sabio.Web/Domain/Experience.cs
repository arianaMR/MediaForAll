using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaForAll.Web.Domain
{
    public class Experience
    {
        public int ExperienceKey { get; set; }

        public int CategoryKey { get; set; }

        public string CategoryName { get; set; }

        public int ExperienceLevel { get; set; }
    }
}