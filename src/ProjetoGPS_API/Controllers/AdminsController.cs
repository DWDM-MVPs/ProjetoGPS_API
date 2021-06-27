using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ProjetoGPS_API.Models;

using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGPS_API.Controllers
{
	[Route("api/admins")]
	[ApiController]
	public class AdminsController : ControllerBase
	{
		private readonly Context _context;

		public AdminsController(Context context)
		{
			_context = context;
		}

		private bool AdminsExists(long id)
		{
			return _context.Admins.Any(e => e.ID == id);
		}



		// ██╗░░░░░░█████╗░░██████╗░██╗███╗░░██╗
		// ██║░░░░░██╔══██╗██╔════╝░██║████╗░██║
		// ██║░░░░░██║░░██║██║░░██╗░██║██╔██╗██║
		// ██║░░░░░██║░░██║██║░░╚██╗██║██║╚████║
		// ███████╗╚█████╔╝╚██████╔╝██║██║░╚███║
		// ╚══════╝░╚════╝░░╚═════╝░╚═╝╚═╝░░╚══╝
		[HttpGet("login/{username}/{encryptedPassword}")]
		public async Task<ActionResult<bool>> Login(string username, string encryptedPassword)
		{
			IQueryable<Admins> admins = _context.Admins.Where(adm => adm.Username == username && adm.Password == encryptedPassword);
			if (admins.Any())
			{
				return this.Ok("Login was successful.");
			}
			return this.Unauthorized("Invalid username and password combination.");
		}



		// ░█████╗░██████╗░███████╗░█████╗░████████╗███████╗
		// ██╔══██╗██╔══██╗██╔════╝██╔══██╗╚══██╔══╝██╔════╝
		// ██║░░╚═╝██████╔╝█████╗░░███████║░░░██║░░░█████╗░░
		// ██║░░██╗██╔══██╗██╔══╝░░██╔══██║░░░██║░░░██╔══╝░░
		// ╚█████╔╝██║░░██║███████╗██║░░██║░░░██║░░░███████╗
		// ░╚════╝░╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝░░░╚═╝░░░╚══════╝
		[HttpPost] // POST: api/Admins
		public async Task<ActionResult<Admins>> PostAdmins(Admins updateAdmin)
		{
			_context.Admins.Add(updateAdmin);
			await _context.SaveChangesAsync();

			return this.CreatedAtAction("GetAdmins", new { id = updateAdmin.ID }, updateAdmin);
		}



		// ██╗░░░██╗██████╗░██████╗░░█████╗░████████╗███████╗
		// ██║░░░██║██╔══██╗██╔══██╗██╔══██╗╚══██╔══╝██╔════╝
		// ██║░░░██║██████╔╝██║░░██║███████║░░░██║░░░█████╗░░
		// ██║░░░██║██╔═══╝░██║░░██║██╔══██║░░░██║░░░██╔══╝░░
		// ╚██████╔╝██║░░░░░██████╔╝██║░░██║░░░██║░░░███████╗
		// ░╚═════╝░╚═╝░░░░░╚═════╝░╚═╝░░╚═╝░░░╚═╝░░░╚══════╝
		[HttpPut("{id}")] // PUT: api/admins/<id>/<admin>
		public async Task<IActionResult> PutAdmins(long id, Admins admins)
		{
			if (id != admins.ID)
			{
				return this.BadRequest();
			}

			_context.Entry(admins).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (this.AdminsExists(id) == false)
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



		// ██████╗░███████╗██╗░░░░░███████╗████████╗███████╗
		// ██╔══██╗██╔════╝██║░░░░░██╔════╝╚══██╔══╝██╔════╝
		// ██║░░██║█████╗░░██║░░░░░█████╗░░░░░██║░░░█████╗░░
		// ██║░░██║██╔══╝░░██║░░░░░██╔══╝░░░░░██║░░░██╔══╝░░
		// ██████╔╝███████╗███████╗███████╗░░░██║░░░███████╗
		// ╚═════╝░╚══════╝╚══════╝╚══════╝░░░╚═╝░░░╚══════╝
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAdmins(long id)
		{
			Admins admins = await _context.Admins.FindAsync(id);
			if (admins == null)
			{
				return this.NotFound();
			}

			_context.Admins.Remove(admins);
			await _context.SaveChangesAsync();

			return this.NoContent();
		}
	}
}
