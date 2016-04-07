//-----------------------------------------------------------------------------
// DriveDiary Web App - an ASP.NET MVC application
//
// Copyright (c) Sami Lakaniemi 2016.  All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DriveDiaryWebApp.Models;

namespace DriveDiaryWebApp.ViewModels
{
    // A viewmodel for showing average consumption per mileage
    public class CarConsumptionVM
    {
        // SL: Details for the car in question (via entity framework)
        public Car vmcar { get; set; }

        // SL: Consumption mileages and amounts for calculation (via custom SQL query)
        public List<ConsumptionPerMileage> vmconsumption { get; set; }

        // SL: Average consumption calculation results
    }
}
