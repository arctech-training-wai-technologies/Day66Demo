using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Day66.Data;
using Day66.Data.Dtos;
using Day66.Data.Models;

namespace Day66.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FlightsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Flights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flight>>> GetFlights()
        {
            if (_context.Flights == null)
            {
                return NotFound();
            }
            return await _context.Flights.ToListAsync();
        }

        // GET: api/Flights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> GetFlight(int id)
        {
            if (_context.Flights == null)
            {
                return NotFound();
            }
            var flight = await _context.Flights.FindAsync(id);

            if (flight == null)
            {
                return NotFound();
            }

            return flight;
        }

        // GET: api/Flights/BOM/DEL/25-Jun-2022
        [HttpGet("{locationFrom}/{locationTo}/{date}")]
        public async Task<ActionResult<List<FlightDto>>> GetFlight(string locationFrom, string locationTo, DateTime date)
        {
            if (!(await _context.Locations.AnyAsync(f => f.AirportName == locationFrom) &&
               await _context.Locations.AnyAsync(f => f.AirportName == locationTo)))
                return NotFound();

            var locationFromRefId = await _context.Locations
                .Where(l => l.AirportName == locationFrom)
                .Select(l => l.Id)
                .FirstOrDefaultAsync();

            var locationToRefId = await _context.Locations
                .Where(l => l.AirportName == locationTo)
                .Select(l => l.Id)
                .FirstOrDefaultAsync();

            var filterDateFrom = date;                              //25-Jun-2022 00:00:00
            var filterDateTo = date.AddHours(24).AddSeconds(-1);    //25-Jun-2022 23:59:59

            var flightsQuery = _context.Flights
                .Where(f =>
                    f.FromLocationRefId == locationFromRefId &&
                    f.ToLocationRefId == locationToRefId &&
                    f.DepartureDateTime >= filterDateFrom && f.DepartureDateTime <= filterDateTo);

            var flightsDto = await _mapper.ProjectTo<FlightDto>(flightsQuery).ToListAsync();

            if (!flightsDto.Any())
                return NotFound();

            return flightsDto;
        }

        // PUT: api/Flights/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlight(int id, Flight flight)
        {
            if (id != flight.Id)
            {
                return BadRequest();
            }

            _context.Entry(flight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Flights
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Flight>> PostFlight(Flight flight)
        {
            if (_context.Flights == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Flights'  is null.");
            }
            _context.Flights.Add(flight);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlight", new { id = flight.Id }, flight);
        }

        // DELETE: api/Flights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            if (_context.Flights == null)
            {
                return NotFound();
            }
            var flight = await _context.Flights.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }

            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlightExists(int id)
        {
            return (_context.Flights?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
