using Microsoft.EntityFrameworkCore;
using XYZHotel.Models;

namespace XYZHotel.DB
{
    public class HotelsContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Hotels> hotels { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Staff> Staffs { get; set;}

        public HotelsContext(DbContextOptions<HotelsContext> options) : base(options)
        {

        }
    }
}
