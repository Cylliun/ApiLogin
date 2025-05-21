namespace ApiLogin.Dto
{
    public class RegisterUserDto
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string ConfirmPassword { get; set; }
    }
}
