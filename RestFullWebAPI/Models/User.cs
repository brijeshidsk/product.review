using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace RestFullWebAPI.Models
{
    public class User
    {
        public enum userRole
        {
            User,
            Admin,
            Seller
        }
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [PasswordPropertyText]
        public string Password { get; set; }
        public userRole Role { get; set; }
        public List<Address>? Addresses { get; set; }
    }
}
