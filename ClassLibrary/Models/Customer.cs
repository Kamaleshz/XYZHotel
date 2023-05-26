using System.ComponentModel.DataAnnotations;

namespace XYZHotel.Models
{
    public class Customer
    {
        [Key]
        public int CutomerId { get; set; }

        public string? CustomerName { get; set; }

        public string? CustomerEmail { get; set; }

        public string? CustomerPassword { get; set; }

        public ICollection<Booking>? bookings { get; set; }
    }
}
