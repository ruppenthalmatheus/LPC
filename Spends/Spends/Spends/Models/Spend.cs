using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spends.Models
{
    public class Spend
    {
        public int idSpend { get; set; }
        public Location location { get; set; }
        public Category category { get; set; }
        public DateTime spendDate { get; set; }
        public decimal total { get; set; }
    }
}