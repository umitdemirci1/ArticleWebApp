using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Validation
{
    public class MailValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            string controlData = string.Empty;
            if (value == null) return new ValidationResult("Email is required.");

            controlData = value.ToString();

            if (controlData.Where(x => x == ' ').ToList().Count > 0)
            {
                return new ValidationResult("Email cannot contain space.");
            }

            if (controlData.Where(x => x == '@').ToList().Count != 1)
            {
                return new ValidationResult("Email must contain one '@' character.");
            }

            if (controlData.Where(x => x == '.').ToList().Count < 1)
            {
                return new ValidationResult("Email must contain at least one '.' character.");
            }

            //it is valid if it ends with @mail.com
            if (controlData.EndsWith("@mail.com"))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Invalid email format or domain.");
        }


    }
}
