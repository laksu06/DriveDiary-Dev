//-----------------------------------------------------------------------------
// DriveDiary Web App - an ASP.NET MVC application
//
// Copyright (c) Sami Lakaniemi 2016.  All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriveDiaryWebApp.Models
{
    public class ConsumptionPerDateTime
    {
        public DateTime RefuelDateTime { get; set; }

        public decimal RefuelAmount { get; set; }

        public decimal AverageConsumption { get; set; }
    }
}