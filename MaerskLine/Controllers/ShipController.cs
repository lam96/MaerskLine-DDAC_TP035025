using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaerskLine.Models;

namespace MaerskLine.Controllers
{
    public class ShipController : Controller
    {
        private ApplicationDbContext db_context;

        public ShipController()
        {
            db_context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            db_context.Dispose();
        }


        // GET: Ships
        public ActionResult Index()
        {
            var ships = db_context.Ships.ToList();

            return View(ships);

        }
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        //ships
        public ActionResult Create(Ship ships)
        {
            db_context.Ships.Add(ships);
            db_context.SaveChanges();

            var Ships = db_context.Ships.ToList();

            return View("Index", Ships);
        }

        public ActionResult Details()
        {
            return View("ShipDetails");
        }

    }
}