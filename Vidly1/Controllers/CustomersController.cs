using System;
using System.Collections.Generic;
using System.Data.Entity;   // Requiered by Eager Loading (Include) ...
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly1.Models;

namespace Vidly1.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Constructor ... Later will replace this with Dependency Injection ...
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            // Later this will be replaced using Dependency Injection ...
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            // Deferred Execution we are no querying the DB until we Iterate de customer's object
            // thta happen usually in the View

            //var customers = _context.Customers.ToList(); // DbSet to get all the Customers from the DB ...
            // Eager Loading: Need to load the relation Customer nad the MembershipType together ...
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int Id)
        {
            /* var customer = (from c in _context.Customers
                             where c.Id == Id
                             //select c.Name).ToList();
                             select c).SingleOrDefault(); */
            //var customer = _context.Customers.Find(Id);
            // var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == Id);

            //return View(detailsViewModel);
            return View(customer);
        }
    }
}