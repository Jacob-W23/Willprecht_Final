﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Willprecht_Final.Models
{
    public partial class DriverInfraction
    {
        public int DriverInfractionId { get; set; }
        public int DriverId { get; set; }
        public int InfractionId { get; set; }

        public virtual Driver Driver { get; set; }
        public virtual Infraction Infraction { get; set; }
    }
}