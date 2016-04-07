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
using System.Web.UI.HtmlControls;

namespace DriveDiaryWebApp.Models
{
    // SL: RefuelEvent model class - represents an entity (row) in the refuel event table
    public class RefuelEvent
    {
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RefuelEventId { get; set; }

        // SL: Foreign key to the Cars table
        [Required]
        public int CarId { get; set; }

        // SL: Custom input validation for mileage
        [Required]
        [RegularExpression(@"^[0-9]{1,7}$",
            ErrorMessage="Mileage should be a less than 7 digit integer.")]
        public int RefuelMileage { get; set; }

        [Required]
        // SL: Custom input validation for datetime value to avoid extra hassle with culture-sensitive formatting
        // (Works for the purposes of this application...)
        [RegularExpression(@"^[0-9]{1,2}\.[0-9]{1,2}\.[0-9]{4}\s[0-9]{2}\:[0-9]{2}\:[0-9]{2}$",
            ErrorMessage="Invalid date. Date should be in 'D.M.YYYY hh:mm:ss' format.")]
        public DateTime RefuelDateTime { get; set; }
        
        // SL: Name and location of gas station (free text)
        // SL: Improvement idea: could use DbGeography datatype for further
        // analysis of refuel locations etc...
        [DataType(DataType.Text)]
        public string RefuelLocation { get; set; }

        // SL: Custom input validation for refuel amount
        [Required]
        [RegularExpression(@"^[0-9]{1,3}[\.\,]{1}[0-9]{2}$",
            ErrorMessage = "Refuel amount should be a decimal number with two decimals (maximum value 999.99).")]
        public decimal RefuelAmount { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal PricePerLiter { get; set; }

        [DataType(DataType.MultilineText)]
        public string RefuelEventDescription { get; set; }

        // SL: Link entity via the foreign key to Cars table
        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }
    }
}
