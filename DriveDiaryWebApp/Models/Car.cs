//-----------------------------------------------------------------------------
// DriveDiary Web App - an ASP.NET MVC application
//
// Copyright (c) Sami Lakaniemi 2016.  All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DriveDiaryWebApp.Models
{
    
    // SL: Car model class - represents an entity (row) in the car table
    public class Car
    {
        // SL: Add Identity to tell Entity Framework that this is a primary key
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarId { get; set; }

        // SL: Mark is required text field
        [Required]
        [DataType(DataType.Text)]
        public string Mark { get; set; }

        // SL: Model designation is required text field
        [Required]
        [DataType(DataType.Text)]
        public string Model { get; set; }
    }
}
