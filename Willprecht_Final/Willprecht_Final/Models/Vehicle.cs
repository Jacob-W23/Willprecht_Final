﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Willprecht_Final.Models
{
    public partial class Vehicle
    {
        public int VehicleId { get; set; }
        public int DriverId { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleYear { get; set; }
        public string LicensePlateNumber { get; set; }

        public virtual Driver Driver { get; set; }
    }
}