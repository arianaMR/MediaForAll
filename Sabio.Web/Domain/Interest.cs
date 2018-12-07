using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaForAll.Web.Domain
{
    public class Interest
    {
        public int InterestKey { get; set; }

        public int CategoryKey { get; set; }

        public string CategoryName { get; set; }

        public int InterestLevel { get; set; }
    }
}