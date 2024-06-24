using Microsoft.EntityFrameworkCore;

namespace BookingManagement.Models
{
    public class BookingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-GBCUGLF4;Integrated Security=true;Initial Catalog=BookingManagement");
        }
        public DbSet<Booking> Bookings { get; set; }
    }
}
