using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoGPS_API.Models;

namespace ProjetoGPS_API.Controllers
{
    [Route("api/placeholders")]
    [ApiController]
    public class PlaceholdersController : ControllerBase
    {
        private readonly Context _context;

        public PlaceholdersController(Context context)
        {
            _context = context;
        }

        // GET: api/Placeholders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Placeholders>>> GetPlaceholders()
        {
            return await _context.Placeholders.ToListAsync();
        }

        // GET: api/Placeholders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Placeholders>> GetPlaceholders(long id)
        {
            var placeholders = await _context.Placeholders.FindAsync(id);

            if (placeholders == null)
            {
                return NotFound();
            }

            return placeholders;
        }

        // PUT: api/Placeholders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaceholders(long id, Placeholders placeholders)
        {
            if (id != placeholders.ID)
            {
                return BadRequest();
            }

            _context.Entry(placeholders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaceholdersExists(id))
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

        // POST: api/Placeholders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Placeholders>> PostPlaceholders(Placeholders placeholders)
        {
            _context.Placeholders.Add(placeholders);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlaceholders", new { id = placeholders.ID }, placeholders);
        }

        // DELETE: api/Placeholders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaceholders(long id)
        {
            var placeholders = await _context.Placeholders.FindAsync(id);
            if (placeholders == null)
            {
                return NotFound();
            }

            _context.Placeholders.Remove(placeholders);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlaceholdersExists(long id)
        {
            return _context.Placeholders.Any(e => e.ID == id);
        }
    }
}
