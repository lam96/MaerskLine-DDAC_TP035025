using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaerskLine.Models;
using System.Globalization;

namespace MaerskLine.Controllers
{
    public class ScheduleController : Controller
    {
        private ApplicationDbContext _context;

        public ScheduleController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            return View("NewSchedule");

        }


        // GET: Schedule
        public ActionResult Index()
        {
            var schedule = _context.Schedules.ToList();
            return View(schedule);
        }

        public ActionResult Create(Schedule schedule)
        {
            _context.Schedules.Add(schedule);

            _context.SaveChanges();

            var newScheduleInDb = _context.Schedules.Find(schedule.ScheduleId);

            return View("ScheduleDetails", newScheduleInDb);

        }

        public ActionResult Edit(int id)
        {
            var schedule = _context.Schedules.SingleOrDefault(s => s.ScheduleId == id);

            if (schedule == null)
            {
                return HttpNotFound();
            }

            Schedule editSchedule = new Schedule();
            editSchedule.ScheduleId = schedule.ScheduleId;
            editSchedule.Destination = schedule.Destination;
            editSchedule.Origin = schedule.Origin;
            editSchedule.DepartTime = schedule.DepartTime;
            editSchedule.ArriveTime = schedule.ArriveTime;

            return View(editSchedule);
        }

        public ActionResult Update(Schedule sch)
        {
            var schedule = _context.Schedules.SingleOrDefault(s => s.ScheduleId == sch.ScheduleId);

            schedule.ScheduleId = sch.ScheduleId;
            schedule.Destination = sch.Destination;
            schedule.Origin = sch.Origin;
            schedule.DepartTime = sch.DepartTime;
            schedule.ArriveTime = sch.ArriveTime;

            _context.SaveChanges();

            var schList = _context.Schedules.ToList();

            return View("Index", schList);
        }

        public ActionResult Delete()
        {
            return View();
        }

        public ActionResult ScheduleDetails(int id)
        {
            var schedule = _context.Schedules.Find(id);

            return View(schedule);
        }



    }
}