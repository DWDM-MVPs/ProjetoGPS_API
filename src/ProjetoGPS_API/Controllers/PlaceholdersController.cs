using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ProjetoGPS_API.Models;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

		private bool PlaceholdersExists(long id)
		{
			return _context.Placeholders.Any(e => e.ID == id);
		}





		// ░██████╗░███████╗████████╗
		// ██╔════╝░██╔════╝╚══██╔══╝
		// ██║░░██╗░█████╗░░░░░██║░░░
		// ██║░░╚██╗██╔══╝░░░░░██║░░░
		// ╚██████╔╝███████╗░░░██║░░░
		// ░╚═════╝░╚══════╝░░░╚═╝░░░
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Placeholders>>> GetPlaceholders()
		{
			return await _context.Placeholders.ToListAsync();
		}





		// ░██████╗░███████╗████████╗  ██████╗░██╗░░░██╗  ██╗██████╗░
		// ██╔════╝░██╔════╝╚══██╔══╝  ██╔══██╗╚██╗░██╔╝  ██║██╔══██╗
		// ██║░░██╗░█████╗░░░░░██║░░░  ██████╦╝░╚████╔╝░  ██║██║░░██║
		// ██║░░╚██╗██╔══╝░░░░░██║░░░  ██╔══██╗░░╚██╔╝░░  ██║██║░░██║
		// ╚██████╔╝███████╗░░░██║░░░  ██████╦╝░░░██║░░░  ██║██████╔╝
		// ░╚═════╝░╚══════╝░░░╚═╝░░░  ╚═════╝░░░░╚═╝░░░  ╚═╝╚═════╝░
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





		// ░█████╗░██████╗░███████╗░█████╗░████████╗███████╗
		// ██╔══██╗██╔══██╗██╔════╝██╔══██╗╚══██╔══╝██╔════╝
		// ██║░░╚═╝██████╔╝█████╗░░███████║░░░██║░░░█████╗░░
		// ██║░░██╗██╔══██╗██╔══╝░░██╔══██║░░░██║░░░██╔══╝░░
		// ╚█████╔╝██║░░██║███████╗██║░░██║░░░██║░░░███████╗
		// ░╚════╝░╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝░░░╚═╝░░░╚══════╝
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





		// ██╗░░░██╗██████╗░██████╗░░█████╗░████████╗███████╗
		// ██║░░░██║██╔══██╗██╔══██╗██╔══██╗╚══██╔══╝██╔════╝
		// ██║░░░██║██████╔╝██║░░██║███████║░░░██║░░░█████╗░░
		// ██║░░░██║██╔═══╝░██║░░██║██╔══██║░░░██║░░░██╔══╝░░
		// ╚██████╔╝██║░░░░░██████╔╝██║░░██║░░░██║░░░███████╗
		// ░╚═════╝░╚═╝░░░░░╚═════╝░╚═╝░░╚═╝░░░╚═╝░░░╚══════╝
		[HttpPost]
		public async Task<ActionResult<Placeholders>> PostPlaceholders(Placeholders placeholders)
		{
			_context.Placeholders.Add(placeholders);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetPlaceholders", new { id = placeholders.ID }, placeholders);
		}





		// ██████╗░███████╗██╗░░░░░███████╗████████╗███████╗
		// ██╔══██╗██╔════╝██║░░░░░██╔════╝╚══██╔══╝██╔════╝
		// ██║░░██║█████╗░░██║░░░░░█████╗░░░░░██║░░░█████╗░░
		// ██║░░██║██╔══╝░░██║░░░░░██╔══╝░░░░░██║░░░██╔══╝░░
		// ██████╔╝███████╗███████╗███████╗░░░██║░░░███████╗
		// ╚═════╝░╚══════╝╚══════╝╚══════╝░░░╚═╝░░░╚══════╝
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
	}
}
