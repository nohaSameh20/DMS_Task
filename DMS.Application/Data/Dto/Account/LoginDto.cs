using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data
{
    public class LoginDto
    {
        public string Name { get; set; }
        public UserRole UserRole { get; set; }
        public string Image { get; set; }
    }
}
