using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class MyDBContext :DbContext
    {
        public MyDBContext(DbContextOptions option) : base(option) 
        {
                
        }

        public DbSet<Student> Students { get; set; }
    }
}
