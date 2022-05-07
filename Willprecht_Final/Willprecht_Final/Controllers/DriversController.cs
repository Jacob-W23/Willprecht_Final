#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Willprecht_Final.Data;
using Willprecht_Final.Models;
using Microsoft.AspNetCore.Authorization;

namespace Willprecht_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly DMVContext _context;

        public DriversController(DMVContext context)
        {
            _context = context;
        }

        public DriversController()
        {
        }

        [Authorize(Roles = "DMV Personnel,Law Enforcement")]
        // GET: api/Drivers
        [HttpGet]
        public IQueryable<Object> GetDrivers()
        {
            return _context.Drivers
                            .Include(d => d.Vehicles)
                            .Include(d => d.DriverInfractions)
                            .Select(d => new
                            {
                                DriverID = d.DriverId,
                                FirstName = d.FirstName,
                                LastName = d.LastName,
                                SSN = d.Ssn,
                                vehicle = d.Vehicles.Select(v => v.VehicleYear + " " + v.VehicleMake + " " + v.VehicleModel).Single(),
                                LicensePlateNumber = d.Vehicles.Select(v => v.LicensePlateNumber).Single(),
                                DriverInfactions = d.DriverInfractions.Select(di => di.Infraction.InfractionType)
                            });
        }

        [Authorize(Roles = "DMV Personnel,Law Enforcement")]
        // GET: api/Drivers/GetDriverBy {FirstName + LastName} {SSN} {PlateNumber}
        [HttpGet("GetDriverBy")]
        public IQueryable<Object> GetDriver(string FirstName = null, string LastName = null, string SSN = null, string PlateNumber = null)
        {
            IQueryable<Object> driver = null;

            if (FirstName != null && LastName !=null)
            {
                driver = _context.Drivers
                            .Include(d => d.Vehicles)
                            .Select(d => new
                            {
                                DriverID = d.DriverId,
                                FirstName = d.FirstName,
                                LastName = d.LastName,
                                SSN = d.Ssn,
                                vehicle = d.Vehicles.Select(v => v.VehicleYear + " " + v.VehicleMake + " " + v.VehicleModel).Single(),
                                LicensePlateNumber = d.Vehicles.Select(v => v.LicensePlateNumber).Single(),
                                DriverInfactions = d.DriverInfractions.Select(di => di.Infraction.InfractionType)
                            })
                            .Where(d => (d.FirstName == FirstName) && (d.LastName == LastName));
            } else if(SSN != null)
            {
                driver =  _context.Drivers
                            .Include(d => d.Vehicles)
                            .Select(d => new
                            {
                                DriverID = d.DriverId,
                                FirstName = d.FirstName,
                                LastName = d.LastName,
                                SSN = d.Ssn,
                                vehicle = d.Vehicles.Select(v => v.VehicleYear + " " + v.VehicleMake + " " + v.VehicleModel).Single(),
                                LicensePlateNumber = d.Vehicles.Select(v => v.LicensePlateNumber).Single(),
                                DriverInfactions = d.DriverInfractions.Select(di => di.Infraction.InfractionType)
                            })
                            .Where(d => d.SSN == SSN);
            } else if (PlateNumber != null)
            {
                driver =  _context.Drivers
                            .Include(d => d.Vehicles)
                            .Select(d => new
                            {
                                DriverID = d.DriverId,
                                FirstName = d.FirstName,
                                LastName = d.LastName,
                                SSN = d.Ssn,
                                vehicle = d.Vehicles.Select(v => v.VehicleYear + " " + v.VehicleMake + " " + v.VehicleModel).Single(),
                                LicensePlateNumber = d.Vehicles.Select(v => v.LicensePlateNumber).Single(),
                                DriverInfactions = d.DriverInfractions.Select(di => di.Infraction.InfractionType)
                            })
                            .Where(d => d.LicensePlateNumber == PlateNumber);
            }

            return driver;
        }

        [Authorize(Roles = "DMV Personnel")]
        // POST: api/Drivers
        [HttpPost]
        public async Task<ActionResult<Driver>> PostDriver(Driver driver)
        {
            _context.Drivers.Add(driver);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDriver", new { id = driver.DriverId }, driver);
        }

        private bool DriverExists(int id)
        {
            return _context.Drivers.Any(e => e.DriverId == id);
        }
    }
}
