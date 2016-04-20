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
using System.Threading;

namespace DriveDiaryWebApp.Controllers
{
    [RequireHttps]
    //[Authorize(Roles="Users")]
    [Authorize]
    public class SignedInHomeController : Controller
    {
        // GET: SignedInHome
        public ActionResult Index()
        {
            ViewBag.ClaimsIdentity = Thread.CurrentPrincipal.Identity;
            return View();
        }
        
        public ActionResult About()
        {
            Trace.TraceInformation(">HomeController:About()");
            ViewBag.ClaimsIdentity = Thread.CurrentPrincipal.Identity;
            ViewBag.Message = "DriveDiary";

            return View();
        }

        public ActionResult Contact()
        {
            Trace.TraceInformation(">HomeController:Contact()");
            ViewBag.ClaimsIdentity = Thread.CurrentPrincipal.Identity;
            ViewBag.Message = "Contact";

            return View();
        }

    }
}