using System.ComponentModel.DataAnnotations;

namespace XYZHotel.Models
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }    

        public string? StaffName { get; set; }
    }
}
