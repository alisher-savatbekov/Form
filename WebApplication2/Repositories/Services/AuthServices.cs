using WebApplication2.DbModel.Model;
using WebApplication2.DbModel.ModelDTO;
using WebApplication2.Repositories.IRepository;

namespace WebApplication2.Repositories.Services;

public class AuthServices:IAuth
{
    public Task<string> JenerateToken(User user)
    {
        throw new NotImplementedException();
    }

    public Task RegistrateUser(RegistrDTO registrDto)
    {
        throw new NotImplementedException();
    }

    public Task<string> LoginUser(LoginDTO loginDto)
    {
        throw new NotImplementedException();
    }
}