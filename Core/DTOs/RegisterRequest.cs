using Core.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.DTOs
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [MailValidation(ErrorMessage = "Invalid email format or domain.")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Password is required.")]
        [PasswordValidation(ErrorMessage = "Invalid email format or domain.")]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Password Confirmation is required.")]
        [Compare("Password", ErrorMessage = "Password Confirmation and password should be same.")]
        public string PasswordConfirmation { get; set; }
        
        [Required(ErrorMessage = "Role is required.")]
        public string Role { get; set; }
    }
}
