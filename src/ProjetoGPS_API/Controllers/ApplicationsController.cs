using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ProjetoGPS_API.Models;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGPS_API.Controllers
{
	[Route("api/applications")]
	[ApiController]
	public class ApplicationsController : ControllerBase
	{
		private readonly Context _context;

		public ApplicationsController(Context context)
		{
			_context = context;
		}

		private bool ApplicationsExists(long id)
		{
			return _context.Applications.Any(e => e.ID == id);
		}






		// ░██████╗░███████╗████████╗  ██████╗░██╗░░░██╗  ████████╗██╗░░░██╗██████╗░███████╗  ░█████╗░███╗░░██╗██████╗░  ░██████╗████████╗░█████╗░████████╗███████╗
		// ██╔════╝░██╔════╝╚══██╔══╝  ██╔══██╗╚██╗░██╔╝  ╚══██╔══╝╚██╗░██╔╝██╔══██╗██╔════╝  ██╔══██╗████╗░██║██╔══██╗  ██╔════╝╚══██╔══╝██╔══██╗╚══██╔══╝██╔════╝
		// ██║░░██╗░█████╗░░░░░██║░░░  ██████╦╝░╚████╔╝░  ░░░██║░░░░╚████╔╝░██████╔╝█████╗░░  ███████║██╔██╗██║██║░░██║  ╚█████╗░░░░██║░░░███████║░░░██║░░░█████╗░░
		// ██║░░╚██╗██╔══╝░░░░░██║░░░  ██╔══██╗░░╚██╔╝░░  ░░░██║░░░░░╚██╔╝░░██╔═══╝░██╔══╝░░  ██╔══██║██║╚████║██║░░██║  ░╚═══██╗░░░██║░░░██╔══██║░░░██║░░░██╔══╝░░
		// ╚██████╔╝███████╗░░░██║░░░  ██████╦╝░░░██║░░░  ░░░██║░░░░░░██║░░░██║░░░░░███████╗  ██║░░██║██║░╚███║██████╔╝  ██████╔╝░░░██║░░░██║░░██║░░░██║░░░███████╗
		// ░╚═════╝░╚══════╝░░░╚═╝░░░  ╚═════╝░░░░╚═╝░░░  ░░░╚═╝░░░░░░╚═╝░░░╚═╝░░░░░╚══════╝  ╚═╝░░╚═╝╚═╝░░╚══╝╚═════╝░  ╚═════╝░░░░╚═╝░░░╚═╝░░╚═╝░░░╚═╝░░░╚══════╝
		[Route("list/{type}/{state}")]
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Applications>>> GetApplications(int type, int state)
		{
			Applications[] applications = await _context.Applications.Where(app => app.Type == type && app.State == state).ToArrayAsync();
			return applications;
		}





		// ░██████╗░███████╗████████╗  ██████╗░██╗░░░██╗  ██╗██████╗░
		// ██╔════╝░██╔════╝╚══██╔══╝  ██╔══██╗╚██╗░██╔╝  ██║██╔══██╗
		// ██║░░██╗░█████╗░░░░░██║░░░  ██████╦╝░╚████╔╝░  ██║██║░░██║
		// ██║░░╚██╗██╔══╝░░░░░██║░░░  ██╔══██╗░░╚██╔╝░░  ██║██║░░██║
		// ╚██████╔╝███████╗░░░██║░░░  ██████╦╝░░░██║░░░  ██║██████╔╝
		// ░╚═════╝░╚══════╝░░░╚═╝░░░  ╚═════╝░░░░╚═╝░░░  ╚═╝╚═════╝░
		[HttpGet("{id}")]
		public async Task<ActionResult<Applications>> GetApplications(long id)
		{
			var applications = await _context.Applications.FindAsync(id);

			if (applications == null)
			{
				return NotFound();
			}

			return applications;
		}





		// ██╗░░░██╗██████╗░██████╗░░█████╗░████████╗███████╗
		// ██║░░░██║██╔══██╗██╔══██╗██╔══██╗╚══██╔══╝██╔════╝
		// ██║░░░██║██████╔╝██║░░██║███████║░░░██║░░░█████╗░░
		// ██║░░░██║██╔═══╝░██║░░██║██╔══██║░░░██║░░░██╔══╝░░
		// ╚██████╔╝██║░░░░░██████╔╝██║░░██║░░░██║░░░███████╗
		// ░╚═════╝░╚═╝░░░░░╚═════╝░╚═╝░░╚═╝░░░╚═╝░░░╚══════╝
		[HttpPut("{id}")]
		public async Task<IActionResult> PutApplications(long id, Applications applications)
		{
			if (id != applications.ID)
			{
				return this.BadRequest();
			}

			_context.Entry(applications).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!this.ApplicationsExists(id))
				{
					return this.NotFound();
				}
				else
				{
					throw;
				}
			}

			return this.NoContent();
		}





		// ░█████╗░██████╗░███████╗░█████╗░████████╗███████╗
		// ██╔══██╗██╔══██╗██╔════╝██╔══██╗╚══██╔══╝██╔════╝
		// ██║░░╚═╝██████╔╝█████╗░░███████║░░░██║░░░█████╗░░
		// ██║░░██╗██╔══██╗██╔══╝░░██╔══██║░░░██║░░░██╔══╝░░
		// ╚█████╔╝██║░░██║███████╗██║░░██║░░░██║░░░███████╗
		// ░╚════╝░╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝░░░╚═╝░░░╚══════╝
		[HttpPost]
		public async Task<ActionResult<Applications>> PostApplications(Applications applications)
		{
			_context.Applications.Add(applications);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetApplications", new { id = applications.ID }, applications);
		}





		// ██████╗░███████╗██╗░░░░░███████╗████████╗███████╗
		// ██╔══██╗██╔════╝██║░░░░░██╔════╝╚══██╔══╝██╔════╝
		// ██║░░██║█████╗░░██║░░░░░█████╗░░░░░██║░░░█████╗░░
		// ██║░░██║██╔══╝░░██║░░░░░██╔══╝░░░░░██║░░░██╔══╝░░
		// ██████╔╝███████╗███████╗███████╗░░░██║░░░███████╗
		// ╚═════╝░╚══════╝╚══════╝╚══════╝░░░╚═╝░░░╚══════╝
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteApplications(long id)
		{
			var applications = await _context.Applications.FindAsync(id);
			if (applications == null)
			{
				return NotFound();
			}

			_context.Applications.Remove(applications);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}
