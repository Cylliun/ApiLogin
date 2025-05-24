using Microsoft.AspNetCore.Identity;

namespace ApiLogin.Models
{
    public class User : IdentityUser
    {
        public int Id {  get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }

    }
}
