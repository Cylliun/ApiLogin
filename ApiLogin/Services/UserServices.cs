using ApiLogin.Data;
using ApiLogin.Dto;
using ApiLogin.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiLogin.Services
{
    public class UserServices : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserServices(AppDbContext context)
        {
            _context = context; 
        }

        public Task<ResponseModel<User>> GetUserDatails(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<User>> PostLogin(UserLoginDto userLoginDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<User>> PostRegister(RegisterUserDto registerUserDto)
        {
            throw new NotImplementedException();
        }
    }
}
