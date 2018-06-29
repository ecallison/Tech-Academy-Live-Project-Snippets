using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ScheduleUsers.Models;
namespace ScheduleUsers.Areas.Employer.Controllers
{
    public class WorkPeriodController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Employer/WorkPeriod
        public ActionResult Index()
        {
            var workPeriods = db.WorkPeriods.Include(w => w.Schedule);
            return View(workPeriods.ToList());
        }
        // GET: Employer/WorkPeriod/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkPeriod workPeriod = db.WorkPeriods.Find(id);
            if (workPeriod == null)
            {
                return HttpNotFound();
            }
            return View(workPeriod);
        }
        // GET: Employer/WorkPeriod/Create
        public ActionResult Create()
        {
            ViewBag.ScheduleId = new SelectList(db.Schedules, "Id", "Notes");
            return View();
        }
        // POST: Employer/WorkPeriod/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartTime,EndTime,ScheduleId,PayRate")] WorkPeriod workPeriod)
        {
            if (ModelState.IsValid)
            {
                db.WorkPeriods.Add(workPeriod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ScheduleId = new SelectList(db.Schedules, "Id", "Notes", workPeriod.ScheduleId);
            return View(workPeriod);
        }
        // GET: Employer/WorkPeriod/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkPeriod workPeriod = db.WorkPeriods.Find(id);
            if (workPeriod == null)
            {
                return HttpNotFound();
            }
            ViewBag.ScheduleId = new SelectList(db.Schedules, "Id", "Notes", workPeriod.ScheduleId);
            return View(workPeriod);
        }
        // POST: Employer/WorkPeriod/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartTime,EndTime,ScheduleId,PayRate")] WorkPeriod workPeriod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workPeriod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ScheduleId = new SelectList(db.Schedules, "Id", "Notes", workPeriod.ScheduleId);
            return View(workPeriod);
        }
        // GET: Employer/WorkPeriod/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkPeriod workPeriod = db.WorkPeriods.Find(id);
            if (workPeriod == null)
            {
                return HttpNotFound();
            }
            return View(workPeriod);
        }
        // POST: Employer/WorkPeriod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            WorkPeriod workPeriod = db.WorkPeriods.Find(id);
            db.WorkPeriods.Remove(workPeriod);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
