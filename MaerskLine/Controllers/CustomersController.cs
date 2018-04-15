using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaerskLine.Models;
using System.Globalization;

namespace MaerskLine.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customer
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            return View();
        }

        // GET: Schedules
        public ActionResult Index()
        {
            var customer = _context.Customers.ToList();

            return View(customer);
        }

        //public ActionResult Create()
        //{
        //    return View();
        //}

        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);

            _context.SaveChanges();


            var newCustomerIndb = _context.Customers.Find(customer.CustomerId);

            return View("CustomerDetails", newCustomerIndb);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(s => s.CustomerId == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            Customer editCustomer = new Customer();
            editCustomer.CustomerId = customer.CustomerId;
            editCustomer.MobilePhoneNumber= customer.MobilePhoneNumber;
            editCustomer.Email = customer.Email;
            editCustomer.Name = customer.Name;

            return View(editCustomer);
        }

        public ActionResult Update(Customer cust)
        {
            var customer = _context.Customers.SingleOrDefault(s => s.CustomerId == cust.CustomerId);

            customer.CustomerId = cust.CustomerId;
            customer.Email = cust.Email;
            customer.MobilePhoneNumber = cust.MobilePhoneNumber;
            customer.Name = cust.Name;


            _context.SaveChanges();

            var custList = _context.Customers.ToList();

            return View("IndexCustomer", custList);
        }

        public ActionResult Delete()
        {
            return View();
        }

        public ActionResult CustomerDetails(int id)
        {
            var schedule = _context.Customers.Find(id);

            return View(schedule);
        }
    }
}