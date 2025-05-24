using ApiLogin.Data;
using ApiLogin.Dto;
using ApiLogin.Models;

namespace ApiLogin.Services
{
    public class UserServices : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserServices(AppDbContext context)
        {
            _context = context; 
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
