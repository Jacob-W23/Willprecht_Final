﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Willprecht_Final.Models
{
    public partial class Driver
    {
        public Driver()
        {
            DriverInfractions = new HashSet<DriverInfraction>();
            Vehicles = new HashSet<Vehicle>();
        }

        public int DriverId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Ssn { get; set; }

        public virtual ICollection<DriverInfraction> DriverInfractions { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}