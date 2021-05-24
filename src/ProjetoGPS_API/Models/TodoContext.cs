using Microsoft.EntityFrameworkCore;

using MySql.Data.MySqlClient;

using System;
using System.Configuration;
using System.Threading.Tasks;

namespace ProjetoGPS_API.Models
{
	public class TodoContext : DbContext
	{
		public TodoContext(DbContextOptions<TodoContext> options) : base(options)
		{
		}

		public DbSet<TodoItem> TodoItem { get; set; }
	}
}
