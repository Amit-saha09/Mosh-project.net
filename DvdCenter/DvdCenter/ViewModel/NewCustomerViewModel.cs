using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DvdCenter.Models;
namespace DvdCenter.ViewModel
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}