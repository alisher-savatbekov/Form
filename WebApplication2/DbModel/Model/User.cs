using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.DbModel.Model;

[Table("User")]
public class User
{
    [Required]
    public Guid id { get; set; } =Guid.NewGuid();
    
    [Required]
    public string username { get; set;}

    [Required]
    public string password { get; set; }
    
    [Required]
    public string email { get; set; }
    
    [Required]
    public Role role { get; set; }
     
    
   

}