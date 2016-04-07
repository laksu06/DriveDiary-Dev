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
    public class ConsumptionPerMileage
    {
        // SL: These will be filled from the custom SQL query - these need to match the column names!
        public int RefuelMileage { get; set; }

        public DateTime RefuelDateTime { get; set; }
        
        public decimal RefuelAmount { get; set; }

        // SL: This will be calculated afterwards, i.e. after the SQL query fills data for the other two properties
        public decimal AverageConsumption { get; set; }
    }
}
