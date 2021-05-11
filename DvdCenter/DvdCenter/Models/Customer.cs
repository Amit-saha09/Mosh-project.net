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

        [Display(Name="Membership Type")]
        public int MembershipTypeId { get; set; }

        [Display(Name="Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        public static readonly int PayasYouGo = 1;
        public static readonly int Unknown = 0;
    }
}