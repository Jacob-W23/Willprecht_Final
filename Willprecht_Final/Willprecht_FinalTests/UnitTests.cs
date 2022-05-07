using Microsoft.VisualStudio.TestTools.UnitTesting;
using Willprecht_Final;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willprecht_Final.Controllers;
using Willprecht_Final.Models;

namespace Willprecht_Final.Tests
{
    [TestClass()]
    public class UnitTests
    {
        [TestMethod()]
        public void AuthenticationSucceedTest()
        {
            JwtAuthenticationManager manager = new JwtAuthenticationManager("thisisthekey1234");

            user testuser = new user
            {
                username = "CJones",
                password = "Jones",
                role = "DMV Personnel"
            };

            var ret = manager.Authentication(testuser.username, testuser.password, testuser.role);

            Assert.IsNotNull(ret);
        }

        [TestMethod()]
        public void AuthenticationFailTest()
        {
            JwtAuthenticationManager manager = new JwtAuthenticationManager("thisisthekey1234");

            user testuser = new user
            {
                username = "CJones",
                password = "Stanley",
                role = "DMV Personnel"
            };

            var ret = manager.Authentication(testuser.username, testuser.password, testuser.role);

            Assert.IsNull(ret);
        }

        [TestMethod()]
        public void HasDriver()
        {

            Vehicle vehicle = new Vehicle
            {
                VehicleMake = "Toyota",
                VehicleModel = "Previa",
                VehicleYear = "2008",
                LicensePlateNumber = "6BL591",
                Driver = new Driver
                {
                    FirstName = "Dennis"
                }
            };

            Assert.IsNotNull(vehicle.Driver.FirstName);
        }

        [TestMethod()]
        public void ValidInfraction()
        {

            Infraction inf = new Infraction
            {
                InfractionType = "Eating While Driving"
            };

            Assert.IsNotNull(inf.InfractionType);
        }

        [TestMethod()]
        public void ValidRole()
        {

            User user = new User
            {
                FirstName = "Test",
                LastName = "User",
                Password = "admin",
                Role = "Law Enforcement"
            };

            Assert.AreEqual(user.Role, "Law Enforcement");
        }

    }
}