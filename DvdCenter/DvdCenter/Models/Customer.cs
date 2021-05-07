using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DvdCenter.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public MembershipType MembershipType { get; set; }
        public int MembershipId { get; set; }
        public DateTime? Birthdate { get; set; }
    }
}