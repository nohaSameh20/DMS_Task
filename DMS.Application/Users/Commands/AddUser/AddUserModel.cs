using Application.Shared;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Users
{
    public class AddUserModel:BaseModel
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { set; get; }

        [Required]
        public UserRole UserRole { get; set; }

        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Sorry, password is required")]
        [MaxLength(14)]
        [MinLength(8, ErrorMessage = "Sorry, password should be at least 8 characters")]
        public string Password { set; get; }

        [MinLength(6)]
        [MaxLength(250)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { set; get; }


        public bool PasswordHashed { set; get; }

        public bool Active { get; set; }
        public bool Deleted { get; set; }


    }
}
