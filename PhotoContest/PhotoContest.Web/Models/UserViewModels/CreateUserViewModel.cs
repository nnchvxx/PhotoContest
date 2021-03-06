using PhotoContest.Services.ExceptionMessages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoContest.Web.Models.UserViewModels
{
    public class CreateUserViewModel
    {
        [Required, StringLength(20, MinimumLength = 2, ErrorMessage = Exceptions.InvalidUserInfo)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required, StringLength(20, MinimumLength = 2, ErrorMessage = Exceptions.InvalidUserInfo)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required, EmailAddress, Display(Name = "Email address")]
        public string Email { get; set; }

        [Required, EmailAddress]
        [Display(Name = "Confirm email address")]
        [Compare(nameof(Email), ErrorMessage = Exceptions.NotMatchingEmail)]
        public string EmailConfirmed { get; set; }

        [Required, MinLength(8), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
