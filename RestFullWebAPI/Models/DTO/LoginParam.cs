using System.ComponentModel.DataAnnotations;

namespace RestFullWebAPI.Models.DTO
{
    public class LoginParam
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
