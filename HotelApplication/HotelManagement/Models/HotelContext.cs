using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Models
{
    public class HotelContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-GBCUGLF4;Integrated Security=true;Initial Catalog=HotelManagement");
        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { H_Id = 1001,H_Name="Royal Stay", City = "chennai",Country="India",Rating=5 }
                );
            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    R_Id = 101,
                    Hotel_Id = 1001,
                    Room_No=111,
                    Price=2000,
                    Type="Non-AC"
                }
                );
        }
    }
}
