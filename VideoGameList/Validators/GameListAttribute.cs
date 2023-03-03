using System.ComponentModel.DataAnnotations;
using VideoGameList.Models;

namespace VideoGameList.Validators
{
	public class GameListAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var game = (Games)validationContext.ObjectInstance;
			if (game.ReleaseYear < 1958)
			{
				return new ValidationResult("Video games weren't around before 1958");
			}
			else if (game.ReleaseYear > 2025)
			{
				return new ValidationResult("Max release year for games is currently 2025");
			}
			else if (game.ReleaseYear.ToString().Length < 4 || game.ReleaseYear.ToString().Length > 4)
			{
				return new ValidationResult("The year cant be shorter or longer than 4 numbers");
			}
			else if (game.Title == "" || game.Title == " ")
			{
				return new ValidationResult("Title can't be left empty");
			}
			else if (game.Rating.ToString().Length > 1)
			{
				return new ValidationResult("The rating can't be longer than one letter");
			}
			else if (game.Platform.Length < 3)
			{
				return new ValidationResult("The platform can't be shorter than 3 letters");
			}
			else if (game.Platform.Length < 3)
			{
				return new ValidationResult("The platform can't be shorter than 3 letters");
			}
			//return base.IsValid(value, validationContext);
			return ValidationResult.Success;
		}
	}
}
