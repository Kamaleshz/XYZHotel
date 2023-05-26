using System.ComponentModel.DataAnnotations;

namespace XYZHotel.Models
{
    public class Hotels
    {
        [Key]
        public int HotelId { get; set; }

        public string? HotelName { get; set;}

        public string? HotelLocation { get; set;}

        public string? HotelAmenities { get; set;}

        public int HotelPrice { get; set;}

        public ICollection<Room>? Rooms { get; set;}

        public ICollection<Staff>? Staffs { get; set;}

        public ICollection<Booking>? Bookings { get; set;}


    }
}
