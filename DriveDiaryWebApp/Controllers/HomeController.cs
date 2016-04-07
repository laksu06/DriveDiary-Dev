//-----------------------------------------------------------------------------
// DriveDiary Web App - an ASP.NET MVC application
//
// Copyright (c) Sami Lakaniemi 2016.  All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// SL: Add log messages for Azure Application Logs ("Trace.WriteLine")
using System.Diagnostics;

namespace DriveDiaryWebApp.Controllers
{
    // SL: Home controller - controls the views on the main page
    //[RequireHttps]
    //[Authorize(Roles="Users")]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // Allow landing page without authentication
        //[AllowAnonymous]
        public ActionResult Index()
        {
            Trace.TraceInformation(">HomeController:Index()");
            return View();
        }

        //[AllowAnonymous]
        public ActionResult About()
        {
            Trace.TraceInformation(">HomeController:About()");
            ViewBag.Message = "DriveDiary";

            return View();
        }

        //[AllowAnonymous]
        public ActionResult Contact()
        {
            Trace.TraceInformation(">HomeController:Contact()");
            ViewBag.Message = "Contact";

            return View();
        }
    }
}
