using Microsoft.EntityFrameworkCore;

namespace UserManagement.Models
{
    public class UserContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-GBCUGLF4;Integrated Security=true;Initial Catalog=UserManagement");
        }
        public DbSet<User> Users { get; set; }
        
    }
}
