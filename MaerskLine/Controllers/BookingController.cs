using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaerskLine.Controllers;
using MaerskLine.Models;
using MaerskLine.ViewModels;
using System.Data.Entity;

namespace MaerskLine.Controllers
{

    public class BookingController : Controller
    {
        // GET: Customer
        private ApplicationDbContext _context;

        public BookingController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        //Select schedule in booking view
        public ActionResult SelectSchedule()
        {
            var schedule = _context.Schedules.ToList();
            return View(schedule);
        }

        //Select Ship in booking view
        public ActionResult ChooseShip(int ScheduleId)
        {
            var schedule = _context.Schedules.SingleOrDefault(s => s.ScheduleId == ScheduleId);
            var shipList = _context.Ships.ToList();

            var viewModel = new MaerskViewModel
            {
                Schedule = schedule,
                Ships = shipList
            };

            return View(viewModel);
        }

        //Select Customer from Booking View

        public ActionResult SelectCustomer(int ScheduleId, int ShipId)
        {
            var schedule = _context.Schedules.SingleOrDefault(s => s.ScheduleId == ScheduleId);

            var ship = _context.Ships.SingleOrDefault(s => s.ShipId == ShipId);

            var CustomerList = _context.Customers.ToList();

            var viewModel = new MaerskViewModel
            {
                Schedule = schedule,
                Ship = ship,

                Customers = CustomerList

            };

            return View(viewModel);
        }
        //Select Container in booking view
        public ActionResult ChooseContainer(int ShipId, int ScheduleId, int CustomerId)
        {
            var schedule = _context.Schedules.SingleOrDefault(s => s.ScheduleId == ScheduleId);
            var Ship = _context.Ships.SingleOrDefault(s => s.ShipId == ShipId);
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == CustomerId);
            var ContainerList = _context.Containers.ToList();

            var viewModel = new MaerskViewModel
            {
                Schedule = schedule,
                Ship = Ship,
                Customer = customer,
                Containers = ContainerList

            };

            return View(viewModel);
        }

        public ActionResult CreateBooking(MaerskViewModel mvm)
        {
            var tempShipID = mvm.Ship.ShipId;

            var newContainerSpace = mvm.Container.WeightInTonne;

            var tempContainerSpace = _context.Ships.Single(s => s.ShipId == tempShipID).ShipContainerNo;

            if (tempContainerSpace - newContainerSpace < 0)
            {
                ViewBag.Error = "The container space is exceeded the ship's container space.";

                var oldSchedule = _context.Schedules.SingleOrDefault(s => s.ScheduleId == mvm.Schedule.ScheduleId);
                var oldShip = _context.Ships.SingleOrDefault(s => s.ShipId == mvm.Ship.ShipId);
                var oldCustomer = _context.Customers.SingleOrDefault(c => c.CustomerId == mvm.Customer.CustomerId);

                var viewModel = new MaerskViewModel
                {
                    Schedule = oldSchedule,
                    Ship = oldShip,
                    Customer = oldCustomer
                };

                return View("SelectContainer", viewModel);
            }

            var ship = _context.Ships.Single(s => s.ShipId == mvm.Ship.ShipId);
            ship.ShipContainerNo = Convert.ToInt32(tempContainerSpace - newContainerSpace);


            var Book = new Booking()
            {
                ScheduleId = mvm.Schedule.ScheduleId,
                ShipId = mvm.Ship.ShipId,
                CustomerId = mvm.Customer.CustomerId,
                BookedAgent = User.Identity.Name,
            };

            var container = new Container()
            {
                ContainerId = mvm.Container.ContainerId,
                ItemsType = mvm.Container.ItemsType,
                WeightInTonne = mvm.Container.WeightInTonne,

                BookingId = mvm.Bookings.BookingId
            };

            _context.Bookings.Add(Book);
            _context.Containers.Add(container);
            _context.SaveChanges();


            var orderList = _context.Containers
                .Include(o => o.Bookings.Schedule)
                .Include(o => o.Bookings.Customer)
                .Include(o => o.Bookings.Ship)
                .Include(o => o.Bookings)
                .ToList();

            return View("ViewOrder", orderList);
        }

        public ActionResult ViewOrder()
        {
            var container = _context.Containers
                .Include(c => c.Bookings)
                .Include(c => c.Bookings.Schedule)
                .Include(c => c.Bookings.Customer)
                .Include(c => c.Bookings.Ship).ToList();

            return View(container);
        }
    }
}
