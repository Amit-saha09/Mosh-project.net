using DvdCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using DvdCenter.ViewModel;
using DvdCenter.Dtos;
using AutoMapper;

namespace DvdCenter.Controllers.Api
{


    public class CustomerController : ApiController
    {


        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        //GET/api/Customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.Include(c=>c.MembershipType).ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }
        //GET/api/customer/1
        public IHttpActionResult GetCustomer( int id)
        {
            var Customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (Customer == null)
                return NotFound();
            return Ok(Mapper.Map<Customer, CustomerDto>(Customer));
        }

        //POST/api/customers
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerdto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerdto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerdto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri+"/"+customer.Id),customerdto);
        }

        private IHttpActionResult Created()
        {
            throw new NotImplementedException();
        }

        //PUT/api/customer
        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateCustomer(int Id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
               return BadRequest();
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customerInDB == null)
               return NotFound();
            Mapper.Map(customerDto, customerInDB);            

            _context.SaveChanges();
            return Ok();


        }
        [System.Web.Http.HttpDelete]
        public IHttpActionResult CustomerDelete(int Id)
        {
          
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customerInDB == null)
               return NotFound();
            _context.Customers.Remove(customerInDB);
            _context.SaveChanges();
            return Ok();
        }

    }
}
