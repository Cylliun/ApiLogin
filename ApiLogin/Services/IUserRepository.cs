using ApiLogin.Dto;
using ApiLogin.Models;

namespace ApiLogin.Services
{
    public interface IUserRepository
    {
        Task<ResponseModel<User>> PostRegister();
        Task<ResponseModel<User>> PostLogin(ListUserDto listUserDto);
        Task<ResponseModel<User>> GetUserDatails(int Id);

    }
}
