using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DbModel.ModelDTO;

public class LoginDTO
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public string password { get; set; }
    
}