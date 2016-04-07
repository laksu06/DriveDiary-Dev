//-----------------------------------------------------------------------------
// DriveDiary Web App - an ASP.NET MVC application
//
// Copyright (c) Sami Lakaniemi 2016.  All rights reserved.
//-----------------------------------------------------------------------------

namespace DriveDiaryWebApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class MigrationsConfiguration : DbMigrationsConfiguration<DriveDiaryWebApp.Models.DriveDiaryWebAppContext>
    {
        public MigrationsConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "DriveDiaryWebApp.Models.DriveDiaryWebAppContext";
        }

        protected override void Seed(DriveDiaryWebApp.Models.DriveDiaryWebAppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
