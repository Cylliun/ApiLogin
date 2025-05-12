using ApiLogin.Dto;
using ApiLogin.Models;

namespace ApiLogin.Services
{
    public class UsuarioServices : IUserRepository
    {
        public Task<ResponseModel<User>> GetUserDatails(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<User>> PostLogin(ListUserDto listUserDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<User>> PostRegister()
        {
            throw new NotImplementedException();
        }
    }
}
