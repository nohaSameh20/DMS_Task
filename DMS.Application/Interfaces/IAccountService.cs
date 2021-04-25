using Application.Data;

namespace Application.Interfaces
{
    public interface IAccountService
    {
        LoginDto Login(LoginModel model);
    }
}