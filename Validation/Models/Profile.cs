using System.ComponentModel.DataAnnotations;

namespace Validation.Models
{
	public class Profile
	{
		[Required(ErrorMessage = "You must enter a name")]
		public string? Name { get; set; }

		[Range(5, 130, ErrorMessage = "Age must between 5 and 130"), Required]
		public int? Age { get; set; }

		[Required(ErrorMessage = "You can't leave this field empty")]
		public string? street { get; set; }

		[Required(ErrorMessage = "You must enter a city")]
		public string? city { get; set; }

		[Required(ErrorMessage = "You must enter a state")]
		public string? state { get; set; }

		[Required(ErrorMessage = "US zip codes are a minimum of 5 numbers")]
		public int? zipcode { get; set; }
	}
}
