using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DvdCenter.Models
{
    public class Min18YearsIfAMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var Customer = (Customer)validationContext.ObjectInstance;
            if (Customer.MembershipTypeId== Customer.Unknown|| Customer.MembershipTypeId == Customer.PayasYouGo)
                return ValidationResult.Success;
            if (Customer.Birthdate == null)
                return new ValidationResult("Birthdate Required");

            var age = DateTime.Today.Year - Customer.Birthdate.Value.Year;
            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer age should be grater then 18 for any Membership.");


        }
    }
}