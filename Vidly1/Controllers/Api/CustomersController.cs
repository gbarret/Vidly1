using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly1.Models;
using Vidly1.Dtos;
using AutoMapper;


namespace Vidly1.Controllers.Api
{
    public class CustomersController : ApiController
    {
        // Defining the context to get the data from the DB ...
        private ApplicationDbContext _context;

        // DbContext Constructor ...
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/customers
        // 20190404 public IEnumerable<Customer> GetCustomers()
        // 20190429 ... public IEnumerable<CustomerDto> GetCustomers() // 20190404 Using Dtos ...
        public IHttpActionResult GetCustomers()
        {
            // 20190404 return _context.Customers.ToList();
            // The Select is a Delegate (without using parenthesis as a reference to a method), otherwise it will be executed inmediatelly ...
            // 20190429 ... return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);

            var customerDtos = _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }

        // GET api/customers/1
        // 20190406 public Customer GetCustomer(int id)
        // 20190409 Refactoring ... public CustomerDto GetCustomer(int id)
        public IHttpActionResult GetCustomer(int id)
        {
            // 20190406 var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                // 20190409 Refactoring ... throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            // 20190406 ... return customer;
            // 20190409 Refactoring ... return Mapper.Map<Customer, CustomerDto>(customer); // This returns a CustomerDto object ...
            return Ok(Mapper.Map<Customer, CustomerDto>(customer)); // This returns a CustomerDto object ...
        }

        // POST /api/customers
        [HttpPost]  // Because we are creating a resource ...
        // 20190406 ... public Customer CreateCustomer(Customer customer)
        // 20190409 Refactoring ... public CustomerDto CreateCustomer(CustomerDto customerDto)
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                // 20190409 Refactoring ...throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();

            // 20190406 ..._context.Customers.Add(customer);
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            //_context.Customers.Add(Mapper.Map<CustomerDto, Customer>(customerDto));
            _context.Customers.Add(customer);
            _context.SaveChanges();

            // 20190406 return customer;
            customerDto.Id = customer.Id;   // 20190406 Retrieving the Id from the Domain Model ...
            // 20190409 Refactoring ... return customerDto;
            // Returning code 201 instead of 200 ... 201 returns more Rest service-specific info ...
            // 20190411 The Uri used to get the new created resource and returning Http code 201 (Rest) ...
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto); 
        }

        // PUT /api/customers/1
        [HttpPut]
        // 20190407 ... public void UpdateCustomer(int id, Customer customer)
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            /* customerInDb.Name = customerDto.Name;
            customerInDb.Birthdate = customerDto.Birthdate;
            customerInDb.IsSubscribedToNewsLetter = customerDto.IsSubscribedToNewsLetter;
            customerInDb.MembershipTypeId = customerDto.MembershipTypeId; */

            // Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);
            Mapper.Map(customerDto, customerInDb);  // This is similar to the previous one, but shorter ...
            _context.SaveChanges();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        // 20190411 ... public void DeleteCustomer(int id)
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                // 20190411 ... throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
