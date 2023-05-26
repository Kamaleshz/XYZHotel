using System.ComponentModel.DataAnnotations;

namespace XYZHotel.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public Customer? Customers { get; set; }

        public Hotels? hotels { get; set; }
    }
}
