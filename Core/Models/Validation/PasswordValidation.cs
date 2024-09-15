using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Core.Models.Validation
{
	public class PasswordValidation : ValidationAttribute
	{
		protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
		{
			if (value == null) return new ValidationResult("Password is required.");

			string password = value.ToString();

			// Password must be at least 8 characters long
			if (password.Length < 8)
			{
				return new ValidationResult("Password must be at least 8 characters long.");
			}

			// Password must contain at least one uppercase letter
			if (!Regex.IsMatch(password, "[A-Z]"))
			{
				return new ValidationResult("Password must contain at least one uppercase letter.");
			}

			// Password must contain at least one lowercase letter
			if (!Regex.IsMatch(password, "[a-z]"))
			{
				return new ValidationResult("Password must contain at least one lowercase letter.");
			}

			// Password must contain at least one digit
			if (!Regex.IsMatch(password, "[0-9]"))
			{
				return new ValidationResult("Password must contain at least one digit.");
			}

			// Password must contain at least one special character
			if (!Regex.IsMatch(password, "[^a-zA-Z0-9]"))
			{
				return new ValidationResult("Password must contain at least one special character.");
			}

			return ValidationResult.Success;
		}
	}
}