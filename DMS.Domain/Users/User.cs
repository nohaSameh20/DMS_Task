using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;
using Domain.Enums;

namespace Domain.Users
{
    [Table(nameof(User))]
    public class User : Entity<Guid>
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
 
        public bool Active { get; set; }
        public bool Deleted { get; set; }

        [Required]
        public string HashPassword { set; get; }

        [Required]
        public string Salt { set; get; }


    }
}