using ApiLogin.Dto;
using ApiLogin.Models;

namespace ApiLogin.Services
{
    public interface IUserRepository
    {
        Task<ResponseModel<User>> PostRegister(RegisterUserDto registerUserDto);
        Task<ResponseModel<User>> PostLogin(UserLoginDto userLoginDto);
        Task<ResponseModel<User>> GetUserDatails(int Id);

    }
}
