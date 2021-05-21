using DvdCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DvdCenter.ViewModel;

namespace DvdCenter.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var MembershipTypes = _context.MembershipType.ToList();
            var ViewModel = new NewCustomerViewModel
            {
                Customer= new Customer(),
                MembershipTypes = MembershipTypes

            };
            return View(ViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipType.ToList()
                };
                return View("New", viewModel);
            }


            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;

            }
           
           
            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            return View(customer);
        }
        public ActionResult Edit( int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipType.ToList()
            };
            return View("New",viewModel);
        }
    }
}