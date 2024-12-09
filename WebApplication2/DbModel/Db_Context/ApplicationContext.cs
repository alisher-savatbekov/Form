using Microsoft.EntityFrameworkCore;
using WebApplication2.DbModel.Model;

namespace WebApplication2.DbModel.Db_Context;

public class ApplicationContext :DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
    {
        
    }
    
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     string connection = "Host=localhost;Database=myform;Username=postgres;Password=klewer123579";
    //     optionsBuilder.UseNpgsql(connection);
    // }
        
    public  DbSet<User> users { get; set; }
    
}