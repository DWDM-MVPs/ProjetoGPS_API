using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;

namespace ProjetoGPS_API.Models
{
	public class Placeholders
	{
		[Key] public string Placeholder { get; set; }
		public string Value { get; set; }
	}
}
