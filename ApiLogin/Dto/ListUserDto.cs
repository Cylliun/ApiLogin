namespace ApiLogin.Dto
{
    public class ListUserDto
    {
        public required string Email { get; set; } 
        public required string PasswordHash { get; set; }
    }
}
