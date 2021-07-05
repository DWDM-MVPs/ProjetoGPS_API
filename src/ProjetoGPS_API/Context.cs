using Microsoft.EntityFrameworkCore;

namespace ProjetoGPS_API.Models
{
	public class Context : DbContext
	{
		public Context(DbContextOptions<Context> options) : base(options)
		{
		}

		public DbSet<Admins> Admins { get; set; }
		public DbSet<Applications> Applications { get; set; }
		public DbSet<Placeholders> Placeholders { get; set; }
	}
}
