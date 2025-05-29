using ApiLogin.Data;
using ApiLogin.Dto;
using ApiLogin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiLogin.Services
{
    public class UserServices : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration; 
        public UserServices(AppDbContext context, UserManager<User> userManager, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<ResponseModel<User>> GetUserDatails(int Id)
        {
            ResponseModel<User> response = new ResponseModel<User>();

            var user = await _context.Users.FindAsync(Id);

            if (user == null) {

                response.Success = false;
                response.Message = "Nenhum usuário encontrado";
                return response;
                
            }

            response.Data = user;
            response.Success = true;
            response.Message = "Usuário encontrado com sucesso";

            return response;


        }

        public async Task<ResponseModel<string>> PostLogin(UserLoginDto userLoginDto)
        {
            ResponseModel<string> response = new ResponseModel<string>();

            var user = await _userManager.FindByEmailAsync(userLoginDto.Email);

            if (user == null) 
            {
                response.Success=false;
                response.Message = "Email do usuário não encontrado";
                return response;
            }

            var passwordValid = await _userManager.CheckPasswordAsync(user, userLoginDto.Password);

            if (!passwordValid)
            {
                response.Success = false;
                response.Message = "A senha está incorreta";
                return response;
            }

            var token = GenerateJwtToken(user);

            response.Data = token;
            response.Success = true;
            response.Message = "Usuário logado com sucesso";
            return response;

        }

        public async Task<ResponseModel<User>> PostRegister(RegisterUserDto registerUserDto)
        {
            ResponseModel<User> response = new ResponseModel<User>();

            var userExist = await _userManager.FindByEmailAsync(registerUserDto.Email);

            if (userExist != null)
            {
                response.Success = false;
                response.Message = "Este Email já está em uso";
                return response;
            }

            var user = new User
            {
                UserName = registerUserDto.UserName,
                Email = registerUserDto.Email
            };

            if (registerUserDto.Password != registerUserDto.ConfirmPassword)
            {
                response.Success = false;
                response.Message = "As senhas elas não coincidem";
                return response;
            }

            var result = await _userManager.CreateAsync(user, registerUserDto.Password);

            if (!result.Succeeded)
            {
                response.Success = false;
                response.Message = "Não é possível criar um usuário!" + string.Join(", ", result.Errors.Select(error => error.Description));
                return response;
            }

            response.Data = user;
            response.Success = true;
            response.Message = "usuario registrado com sucesso";
            return response;

        }

        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var token = new JwtSecurityToken(
                
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
             );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
