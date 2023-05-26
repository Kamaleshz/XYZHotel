using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        public int RoomNumber { get; set; }

        public string RoomName { get; set; }

        public Hotels? hotels { get; set; }
    }
}
