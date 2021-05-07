using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdCenter.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Cost { get; set; }
        public int Discount { get; set; }
    }
}