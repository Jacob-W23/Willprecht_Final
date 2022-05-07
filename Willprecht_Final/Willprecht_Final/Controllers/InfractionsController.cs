#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Willprecht_Final.Data;
using Willprecht_Final.Models;

namespace Willprecht_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfractionsController : ControllerBase
    {
        private readonly DMVContext _context;

        public InfractionsController(DMVContext context)
        {
            _context = context;
        }

        // GET: api/Infractions
        [Authorize(Roles = "Law Enforcement")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Infraction>>> GetInfractions()
        {
            return await _context.Infractions.ToListAsync();
        }

        private bool InfractionExists(int id)
        {
            return _context.Infractions.Any(e => e.InfractionId == id);
        }
    }
}
