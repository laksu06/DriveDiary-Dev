//-----------------------------------------------------------------------------
// DriveDiary Web App - an ASP.NET MVC application
//
// Copyright (c) Sami Lakaniemi 2016.  All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Data.Entity;

namespace DriveDiaryWebApp.Models
{
    public class TenantDbContext : DbContext
    {
        public TenantDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<IssuingAuthorityKey> IssuingAuthorityKeys { get; set; }

        public DbSet<Tenant> Tenants { get; set; }
    }
}
