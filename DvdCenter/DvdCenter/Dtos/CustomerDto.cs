using DvdCenter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DvdCenter.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

       
        public int MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }


        //   [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}