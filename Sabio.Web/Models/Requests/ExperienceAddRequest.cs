using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaForAll.Web.Models
{
    public class ExperienceAddRequest
    {
        public int CategoryKey { get; set; }

        public int ExperienceLevel { get; set; }
    }
}