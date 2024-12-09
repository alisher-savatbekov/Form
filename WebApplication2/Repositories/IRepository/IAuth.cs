using WebApplication2.DbModel.Model;
using WebApplication2.DbModel.ModelDTO;

namespace WebApplication2.Repositories.IRepository;

public interface IAuth
{
      string JenerateToken(User user);
     Task RegistrateUser(RegistrDTO registrDto);
    Task<string> LoginUser(LoginDTO loginDto);
}