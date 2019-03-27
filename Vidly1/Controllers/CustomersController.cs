using System;
using System.Collections.Generic;
using System.Data.Entity;   // Requiered by Eager Loading (Include) ...
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly1.Models;
using Vidly1.ViewModels;

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

        public ActionResult New()
        {
            // Initializing MembershipTypes used for the Form's DropDown ...
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes,
            };

            // Override the View to go to "CustomerForm" instead of using the default "New"...
            // return View(viewModel);
            return View("CustomerForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            // Getting data from DB ...
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            // Checking if customer exist in ghe DB ...

            if (customer == null)
                return HttpNotFound();

            // I need the View Model ...
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                // Initializing MembershipTypes used for the DropDown ...
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            // Override the View to go to "CustomerForm" instead of using the default "Edit" ...
            return View("CustomerForm", viewModel);
        }


        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                // Getting Data from Db ...
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);


                // 20180324 see Comments ... 
                // 20180324 TryUpdateModel(customerInDb);   // Updates all the properties in the model, but what about if only we need to update only some of the properties? ...
                // TryUpdateModel as suggested by Microsoft is not a good practice because we need to
                // type the properties names. Something that is not updated automatically in case
                // a propertie(s) gets renamed as a result of Re-factoring ...
                // 20180324 see Comments ... 
                // 20180324 TryUpdateModel(customerInDb, "", new string[] { "Name", "Birthdate"}); // This can update only some of the properties ..

                // Mosh recommends to update property by property as shown below ...
                // Updating only some properties ...
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                // To replace the previous lines, we can use a library like "AutoMapper" that can match the names in form with the names in the DB
                // using something like this ... Mapper.Map(customer, customerInDb);
                // Also, as a complemet to Mapper we can define a new class that contains only the properties to be updated ...
                // The new class can be something like "UpdateCustomerDto instead of using class "Customer") ..
                // This AutoMapper can update safely only the properties that need to be updated ... 
            }

            _context.SaveChanges();

            return RedirectToAction("Index","Customers");
        }
    }
}