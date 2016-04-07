//-----------------------------------------------------------------------------
// DriveDiary Web App - an ASP.NET MVC application
//
// Copyright (c) Sami Lakaniemi 2016.  All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
// SL: Add log messages for Azure Application Logs ("Trace.WriteLine")
using System.Diagnostics;
// SL: Add Migrations for automatic database migrations
using DriveDiaryWebApp.Migrations;

namespace DriveDiaryWebApp.Models
{
    public class DriveDiaryWebAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public DriveDiaryWebAppContext()
            : base("name=DriveDiaryWebAppContext")
        {
            // SL: Add some diagnostics to find out which database we are connecting to
            Trace.TraceInformation("DriveDiaryWebAppContext:DriveDiaryWebAppContext()");
            //Trace.TraceInformation("Connection string: {0}",
            //    ConfigurationManager.ConnectionStrings["DriveDiaryWebAppContext"]);
            // SL: Run automatic migration of database at application launch
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<DriveDiaryWebAppContext, MigrationsConfiguration>());

        }

        public List<ConsumptionPerMileage> GetConsumptionPerMileageData(int? id, int startMileage, int endMileage)
        {
            Trace.TraceInformation(">DriveDiaryWebAppContext:GetConsumptionPerMileageData()");
            try
            {
                var query =
                  "SELECT RefuelEvents.RefuelMileage, RefuelEvents.RefuelDateTime, RefuelEvents.RefuelAmount "
                + "FROM Cars\n"
	            + "INNER JOIN RefuelEvents\n"
	            + "ON Cars.Id = RefuelEvents.CarId\n"
	            + "WHERE Cars.Id=" + id + "\n"
	            + "ORDER BY RefuelEvents.RefuelMileage;";
                Trace.TraceInformation("-DriveDiaryWebAppContext:GetConsumptionPerMileageData, query string set as: {0}", query);
                return Database.SqlQuery<ConsumptionPerMileage>(query).ToList();
            }
            catch( Exception e)
            {
                Trace.TraceError("-DriveDiaryWebAppContext:GetConsumptionPerMileageData, Exception thrown: {0}", e.GetType());
                // SL: In case of an exception, return an empty list
                return new List<ConsumptionPerMileage>();
            }
        }

        public System.Data.Entity.DbSet<DriveDiaryWebApp.Models.Car> Cars { get; set; }

        public System.Data.Entity.DbSet<DriveDiaryWebApp.Models.RefuelEvent> RefuelEvents { get; set; }
    
    }
}
