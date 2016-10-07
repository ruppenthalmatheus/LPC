using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Association.Models
{
    public class Member
    {
        public int id { get; set; }
        public string name { get; set; }
        public City city { get; set; }
    }       
}