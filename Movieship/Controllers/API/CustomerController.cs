using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Movieship.Models;
using Movieship.DTOs;
using System.Data.Entity;


using AutoMapper;

namespace Movieship.Controllers.API
{
    
    public class CustomerController : ApiController
    {

        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        //GEt/api/customers beacause we are returning a list of object
        // we use data transfer object here so that client part directly not connect
        // to our domain part. we will create layer on our domain part with the help
        // of data object tranfere were we can keep only properties 
        //which we neewded to show 
        //after that we use automapper to mapp dto's property automatically

        // Get api/Customer
        [HttpGet]
        public IHttpActionResult GetCustomers(string query = null) 
        {
            var customersQuery = _context.Customer
                .Include(c => c.MemberShip);

            if (!String.IsNullOrWhiteSpace(query))
               customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }

        //gt api/customer/id
        [HttpGet]
        public IHttpActionResult GetCustomer(int Id)
        {
            var custr = _context.Customer.SingleOrDefault(c => c.Id == Id);
            if (custr == null)
                return NotFound();
            return Ok( Mapper.Map<Customer, CustomerDto>(custr));
        }

        //post api/customer
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageCustomer)]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            if (customer == null)
                return NotFound();
            _context.Customer.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        [HttpPut]
        [Authorize(Roles = RoleName.CanManageCustomer)]
        public IHttpActionResult  UpdateCustomer(int Id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var custInDb = _context.Customer.SingleOrDefault(c => c.Id == Id);

            if (custInDb == null)
                return NotFound();

            Mapper.Map(customerDto, custInDb);
           
            _context.SaveChanges();

            return Ok();


        }
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageCustomer)]
        public IHttpActionResult DeleteCustomer(int Id)
        {
            if (!ModelState.IsValid)
               return BadRequest();
            var custInDb = _context.Customer.SingleOrDefault(c => c.Id == Id);

            if (custInDb == null)
             return NotFound();

            _context.Customer.Remove(custInDb);

            _context.SaveChanges();

            return Ok();


        }
    }
}
