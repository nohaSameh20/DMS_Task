using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users
{
    public interface IAddUserCommand
    {
        Guid Execute(AddUserModel model);
    }
}
