using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        //DB
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();    
        }


        // GET: Customers
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            //var customers = GetCustomers();

            //var customers = new List<Customer>
            //{
            //    new Customer { Id = 1, Name = "Bartłomiej", Surname = "Płoszyński"},
            //    new Customer { Id = 2, Name = "Marta", Surname = "Dąbrowska" }
            //};

            if (customers != null)
            {
                return View(customers);
            }
            else
            {
                return HttpNotFound();
            }

            //return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>
        //     {
        //         new Customer { Id = 1, Name = "John", Surname = "Apollo" },
        //         new Customer { Id = 2, Name = "Mary", Surname = "Belba" }
        //     };
        //}

        //GET: Customers/details
        public ActionResult Details (int? id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        //GET: Customers/new
        public ActionResult New ()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipType = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipType = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Surname = customer.Surname;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;   
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
        public ActionResult Edit (int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipType = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel); 
        }
    }
}