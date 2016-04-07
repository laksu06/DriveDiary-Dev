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
// SL: Add log messages for Azure Application Logs ("Trace.WriteLine")
using System.Diagnostics;
// SL: For consumption view
using DriveDiaryWebApp.ViewModels;

namespace DriveDiaryWebApp.Controllers
{
    //[Authorize(Roles = "users")]
    [Authorize]
    public class CarsController : Controller
    {
        private DriveDiaryWebAppContext db = new DriveDiaryWebAppContext();

        // GET: Cars
        public ActionResult Index()
        {
            Trace.TraceInformation(">CarsController:Index()");
            // SL: Break down this sentence: "return View(db.Cars.ToList());" to ease debugging
            List<Car> cars = new List<Car>(db.Cars.ToList());
            Trace.TraceInformation("<CarsController:Index()");
            return View(cars);
        }

        /*
         * SL: ConsumptionPerMileage - calculate consumption for the car view model
         * */
        public ActionResult ConsumptionPerMileage(int? id)
        {
            Trace.TraceInformation(">CarsController:ConsumptionPerMileage() id: {0}", id);

            CarConsumptionVM carconvm = new CarConsumptionVM();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // SL: First, get the car entity from database
            carconvm.vmcar = db.Cars.Find(id);
            if (carconvm.vmcar == null)
            {
                return HttpNotFound();
            }
            
            // SL: Next, get the consumption data for this car entity
            // SL: The km interval is hard-coded, TODO: add user selectable interval
            carconvm.vmconsumption =
                new List<Models.ConsumptionPerMileage>(
                    db.GetConsumptionPerMileageData(id,
                    0, 200000));

            if(carconvm.vmconsumption.Count == 0)
            {
                return View(carconvm);
            }

            // SL: Calculate average consumptions here
            for( int index=0; index < carconvm.vmconsumption.Count; index++)
            {
                if (index == 0)
                {
                    // SL: Set the consumption of the first item (row) as zero
                    // (No previous calculation point available)
                    carconvm.vmconsumption[index].AverageConsumption = 0;
                }
                else
                {
                    try
                    {
                    // SL: Calculate consumption (l/100 km) for current interval
                        carconvm.vmconsumption[index].AverageConsumption =
                            (100 * carconvm.vmconsumption[index].RefuelAmount) /
                            (carconvm.vmconsumption[index].RefuelMileage -
                             carconvm.vmconsumption[index - 1].RefuelMileage);
                        carconvm.vmconsumption[index].AverageConsumption =
                            Decimal.Round(carconvm.vmconsumption[index].AverageConsumption, 1);
                    }
                    catch( Exception e)
                    {
                        // SL: In case of exception, set the calculated consumption as zero
                        Trace.TraceError("-CarsController:ConsumptionPerMileage(), exception thrown when calculating consumption: {0}", e.GetType());
                        carconvm.vmconsumption[index].AverageConsumption = 0;
                    }
                }
            }
            Trace.TraceInformation("<CarsController:ConsumptionPerMileage()");
            return View(carconvm);
        }
#if testi
        public ActionResult ConsumptionPerDateTime(int? id)
        {
            Trace.TraceInformation(">CarsController:ConsumptionPerDateTime() id: {0}", id);

            CarConsumptionVM carconvm = new CarConsumptionVM();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // SL: First, get the car entity from database
            carconvm.vmcar = db.Cars.Find(id);
            if (carconvm.vmcar == null)
            {
                return HttpNotFound();
            }

            // SL: Next, get the consumption data for this car entity
            // SL: The datetime interval is hard-coded, TODO: add user selectable interval
            carconvm.vmconsumption =
                new List<Models.ConsumptionPerMileage>(
                    db.GetConsumptionPerMileageData(id,
                    0, 200000));

            if (carconvm.vmconsumptionperdatetime.Count == 0)
            {
                return View(carconvm);
            }

            // SL: Calculate average consumptions here
            for (int index = 0; index < carconvm.vmconsumptionperdatetime.Count; index++)
            {
                if (index == 0)
                {
                    // SL: Set the consumption of the first item (row) as zero
                    // (No previous calculation point available)
                    carconvm.vmconsumptionperdatetime[index].AverageConsumption = 0;
                }
                else
                {
                    try
                    {
                        // SL: Calculate consumption (l/100 km) for current interval
                        carconvm.vmconsumptionpermileage[index].AverageConsumption =
                            (100 * carconvm.vmconsumptionpermileage[index].RefuelAmount) /
                            (carconvm.vmconsumptionpermileage[index].RefuelMileage -
                             carconvm.vmconsumptionpermileage[index - 1].RefuelMileage);
                    }
                    catch (Exception e)
                    {
                        // SL: In case of exception, set the calculated consumption as zero
                        Trace.TraceError("-CarsController:ConsumptionPerMileage(), exception thrown when calculating consumption: {0}", e.GetType());
                        carconvm.vmconsumptionpermileage[index].AverageConsumption = 0;
                    }
                }
            }
            Trace.TraceInformation("<CarsController:ConsumptionPerMileage()");
            return View(carconvm);
        }

#endif
        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            Trace.TraceInformation(">CarsController:Details() id: {0}", id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            Trace.TraceInformation("<CarsController:Details()");
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            Trace.TraceInformation(">CarsController:Create()");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarId,Mark,Model")] Car car)
        {
            Trace.TraceInformation(">CarsController:Create() POST");
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            Trace.TraceInformation(">CarsController:Edit() id: {0}", id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarId,Mark,Model")] Car car)
        {
            Trace.TraceInformation(">CarsController:Edit() POST");
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            Trace.TraceInformation(">CarsController:Delete() id: {0}", id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trace.TraceInformation(">CarsController:DeleteConfirmed() POST");
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            // SL: Exception handling for Cars controller - show the error view with exception details
            Exception exception = filterContext.Exception;
            if (exception != null)
            {
                filterContext.ExceptionHandled = true;

                var result = this.View("Error", new HandleErrorInfo(exception,
                    filterContext.RouteData.Values["controller"].ToString(),
                    filterContext.RouteData.Values["action"].ToString()));
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
