using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IHashService
    {
        string CreateSalt();
        string Create(string value, string salt);
        bool Validate(string value, string salt, string hash);
    }
}
