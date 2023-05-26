using System.ComponentModel.DataAnnotations;
using ClassLibrary.Models;

namespace ClassLibrary.Models
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
