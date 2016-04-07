//-----------------------------------------------------------------------------
// DriveDiary Web App - an ASP.NET MVC application
//
// Copyright (c) Sami Lakaniemi 2016.  All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DriveDiaryWebApp.Models;

namespace DriveDiaryWebApp.Controllers
{
    //[Authorize(Roles = "users")]
    [Authorize]
    public class RefuelEventsController : Controller
    {
        private DriveDiaryWebAppContext db = new DriveDiaryWebAppContext();

        // GET: RefuelEvents
        public ActionResult Index()
        {
            var refuelEvents = db.RefuelEvents.Include(r => r.Car);
            return View(refuelEvents.ToList());
        }

        // GET: RefuelEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RefuelEvent refuelEvent = db.RefuelEvents.Find(id);
            if (refuelEvent == null)
            {
                return HttpNotFound();
            }
            return View(refuelEvent);
        }

        // GET: RefuelEvents/Create
        public ActionResult Create()
        {
            ViewBag.CarId = new SelectList(db.Cars, "CarId", "Mark");
            return View();
        }

        // POST: RefuelEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RefuelEventId,CarId,RefuelMileage,RefuelDateTime,RefuelLocation,RefuelAmount,PricePerLiter,RefuelEventDescription")] RefuelEvent refuelEvent)
        {
            if (ModelState.IsValid)
            {
                db.RefuelEvents.Add(refuelEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarId = new SelectList(db.Cars, "CarId", "Mark", refuelEvent.CarId);
            return View(refuelEvent);
        }

        // GET: RefuelEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RefuelEvent refuelEvent = db.RefuelEvents.Find(id);
            if (refuelEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarId = new SelectList(db.Cars, "CarId", "Mark", refuelEvent.CarId);
            return View(refuelEvent);
        }

        // POST: RefuelEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RefuelEventId,CarId,RefuelMileage,RefuelDateTime,RefuelLocation,RefuelAmount,PricePerLiter,RefuelEventDescription")] RefuelEvent refuelEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(refuelEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarId = new SelectList(db.Cars, "CarId", "Mark", refuelEvent.CarId);
            return View(refuelEvent);
        }

        // GET: RefuelEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RefuelEvent refuelEvent = db.RefuelEvents.Find(id);
            if (refuelEvent == null)
            {
                return HttpNotFound();
            }
            return View(refuelEvent);
        }

        // POST: RefuelEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RefuelEvent refuelEvent = db.RefuelEvents.Find(id);
            db.RefuelEvents.Remove(refuelEvent);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            // SL: Exception handling for RefuelEvents controller - show the error view with exception details
            Exception exception = filterContext.Exception;
            if(exception != null)
            {
                filterContext.ExceptionHandled = true;

                var result = this.View("Error", new HandleErrorInfo(exception,
                    filterContext.RouteData.Values["controller"].ToString(),
                    filterContext.RouteData.Values["action"].ToString()));
                ViewBag.ExceptionMessage = exception.Message;
                filterContext.Result = result;
            }
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
