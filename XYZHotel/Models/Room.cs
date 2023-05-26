using System.ComponentModel.DataAnnotations;

namespace XYZHotel.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        public int RoomNumber { get; set; }

        public int RoomName { get; set; }

        public Hotels? hotels { get; set; }
    }
}
