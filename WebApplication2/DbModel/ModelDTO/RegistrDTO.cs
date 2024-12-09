using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DbModel.ModelDTO;

public class RegistrDTO
{
    [Required]
    public string username { get; set;}

    [Required]
    public string password { get; set; }
    
    [Required]
    public string email { get; set; }
}