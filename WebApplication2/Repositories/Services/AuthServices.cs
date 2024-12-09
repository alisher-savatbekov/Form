using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApplication2.DbModel.Db_Context;
using WebApplication2.DbModel.Model;
using WebApplication2.DbModel.ModelDTO;
using WebApplication2.Repositories.IRepository;

namespace WebApplication2.Repositories.Services;

public class AuthServices : IAuth
{
    private readonly ApplicationContext _context;

    public AuthServices(ApplicationContext context)
    {
        _context = context;
    }


    public string JenerateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.email),
            new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
            new Claim(ClaimTypes.Role, user.role),
            new Claim(ClaimTypes.Name, user.username)

        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MyFromBrother123579"));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "MyIssuer",
            audience: "MyAudience",
            claims: claims,
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);

    }


public async Task RegistrateUser(RegistrDTO registrDto)
    {
        try
        {

            if (!registrDto.Equals(null))
            {
                throw new Exception("Model is null");
            }

            var existing =
                await _context.users.FirstOrDefaultAsync(t =>
                    t.email == registrDto.email || t.username == registrDto.username);

            if (existing != null)
            {
                throw new Exception("Invalid username or email");
            }


            var model = new User
            {
                username = registrDto.username,
                password = BCrypt.Net.BCrypt.HashPassword(registrDto
                    .password), //hashing password for unusing it by admin
                email = registrDto.email
            };


            //Add user 
            _context.Add(model);
            await _context.SaveChangesAsync();
        }
        catch(Exception e)
        {
            throw new Exception(e.Message);
        }
        
    }

    public async Task<string> LoginUser(LoginDTO loginDto)
    {
        try
        {
            var user = await _context.users.FirstOrDefaultAsync(u => u.email == loginDto.Email);
            if (user == null)
            {
                throw new Exception("User is unknown");
            }

            bool isPassword = BCrypt.Net.BCrypt.Verify(user.password, loginDto.password);

            if (!isPassword)
            {
                throw new Exception("Password is incorrect");
            }
            
            var token = JenerateToken(user);
            
            //Хотел добавить время чтоб сохранить но не сделал 
            await _context.SaveChangesAsync();

            return token;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);

        }
    }
}