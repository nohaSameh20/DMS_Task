using Application.Shared;
using System.ComponentModel.DataAnnotations;

namespace Application.Data
{
    public class LoginModel : BaseModel
    {
        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { set; get; }

        
        [Required(AllowEmptyStrings = false)]
        public string Password { set; get; }
    }
}