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

		private bool PlaceholdersExists(string name)
		{
			return _context.Placeholders.Any(e => e.Placeholder == name);
		}





		// ░██████╗░███████╗████████╗  ██████╗░██╗░░░██╗  ██████╗░██╗░░░░░░█████╗░░█████╗░███████╗██╗░░██╗░█████╗░██╗░░░░░██████╗░███████╗██████╗░
		// ██╔════╝░██╔════╝╚══██╔══╝  ██╔══██╗╚██╗░██╔╝  ██╔══██╗██║░░░░░██╔══██╗██╔══██╗██╔════╝██║░░██║██╔══██╗██║░░░░░██╔══██╗██╔════╝██╔══██╗
		// ██║░░██╗░█████╗░░░░░██║░░░  ██████╦╝░╚████╔╝░  ██████╔╝██║░░░░░███████║██║░░╚═╝█████╗░░███████║██║░░██║██║░░░░░██║░░██║█████╗░░██████╔╝
		// ██║░░╚██╗██╔══╝░░░░░██║░░░  ██╔══██╗░░╚██╔╝░░  ██╔═══╝░██║░░░░░██╔══██║██║░░██╗██╔══╝░░██╔══██║██║░░██║██║░░░░░██║░░██║██╔══╝░░██╔══██╗
		// ╚██████╔╝███████╗░░░██║░░░  ██████╦╝░░░██║░░░  ██║░░░░░███████╗██║░░██║╚█████╔╝███████╗██║░░██║╚█████╔╝███████╗██████╔╝███████╗██║░░██║
		// ░╚═════╝░╚══════╝░░░╚═╝░░░  ╚═════╝░░░░╚═╝░░░  ╚═╝░░░░░╚══════╝╚═╝░░╚═╝░╚════╝░╚══════╝╚═╝░░╚═╝░╚════╝░╚══════╝╚═════╝░╚══════╝╚═╝░░╚═╝
		[HttpGet("{placeholder}")]
		public async Task<ActionResult<Placeholders>> GetPlaceholders(string placeholder)
		{
			Placeholders placeholders = await _context.Placeholders.Where(p => p.Placeholder == placeholder).FirstOrDefaultAsync();

			if (placeholders == null)
			{
				return this.NotFound();
			}

			return placeholders;
		}





		// ██╗░░░██╗██████╗░██████╗░░█████╗░████████╗███████╗  ██████╗░██╗░░░██╗  ██████╗░██╗░░░░░░█████╗░░█████╗░███████╗██╗░░██╗░█████╗░██╗░░░░░██████╗░███████╗██████╗░
		// ██║░░░██║██╔══██╗██╔══██╗██╔══██╗╚══██╔══╝██╔════╝  ██╔══██╗╚██╗░██╔╝  ██╔══██╗██║░░░░░██╔══██╗██╔══██╗██╔════╝██║░░██║██╔══██╗██║░░░░░██╔══██╗██╔════╝██╔══██╗
		// ██║░░░██║██████╔╝██║░░██║███████║░░░██║░░░█████╗░░  ██████╦╝░╚████╔╝░  ██████╔╝██║░░░░░███████║██║░░╚═╝█████╗░░███████║██║░░██║██║░░░░░██║░░██║█████╗░░██████╔╝
		// ██║░░░██║██╔═══╝░██║░░██║██╔══██║░░░██║░░░██╔══╝░░  ██╔══██╗░░╚██╔╝░░  ██╔═══╝░██║░░░░░██╔══██║██║░░██╗██╔══╝░░██╔══██║██║░░██║██║░░░░░██║░░██║██╔══╝░░██╔══██╗
		// ╚██████╔╝██║░░░░░██████╔╝██║░░██║░░░██║░░░███████╗  ██████╦╝░░░██║░░░  ██║░░░░░███████╗██║░░██║╚█████╔╝███████╗██║░░██║╚█████╔╝███████╗██████╔╝███████╗██║░░██║
		// ░╚═════╝░╚═╝░░░░░╚═════╝░╚═╝░░╚═╝░░░╚═╝░░░╚══════╝  ╚═════╝░░░░╚═╝░░░  ╚═╝░░░░░╚══════╝╚═╝░░╚═╝░╚════╝░╚══════╝╚═╝░░╚═╝░╚════╝░╚══════╝╚═════╝░╚══════╝╚═╝░░╚═╝
		[HttpPut("{name}")]
		public async Task<IActionResult> PutPlaceholders(string name, Placeholders placeholders)
		{
			if (name != placeholders.Placeholder)
			{
				return this.BadRequest();
			}

			_context.Entry(placeholders).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!this.PlaceholdersExists(name))
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
	}
}
