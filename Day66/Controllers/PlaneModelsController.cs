using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Day66.Data;
using Day66.Data.Models;

namespace Day66.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaneModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PlaneModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PlaneModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaneModel>>> GetPlaneModels()
        {
          if (_context.PlaneModels == null)
          {
              return NotFound();
          }
            return await _context.PlaneModels.ToListAsync();
        }

        // GET: api/PlaneModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlaneModel>> GetPlaneModel(int id)
        {
          if (_context.PlaneModels == null)
          {
              return NotFound();
          }
            var planeModel = await _context.PlaneModels.FindAsync(id);

            if (planeModel == null)
            {
                return NotFound();
            }

            return planeModel;
        }

        // PUT: api/PlaneModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaneModel(int id, PlaneModel planeModel)
        {
            if (id != planeModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(planeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaneModelExists(id))
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

        // POST: api/PlaneModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlaneModel>> PostPlaneModel(PlaneModel planeModel)
        {
          if (_context.PlaneModels == null)
          {
              return Problem("Entity set 'ApplicationDbContext.PlaneModels'  is null.");
          }
            _context.PlaneModels.Add(planeModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlaneModel", new { id = planeModel.Id }, planeModel);
        }

        // DELETE: api/PlaneModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaneModel(int id)
        {
            if (_context.PlaneModels == null)
            {
                return NotFound();
            }
            var planeModel = await _context.PlaneModels.FindAsync(id);
            if (planeModel == null)
            {
                return NotFound();
            }

            _context.PlaneModels.Remove(planeModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlaneModelExists(int id)
        {
            return (_context.PlaneModels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
