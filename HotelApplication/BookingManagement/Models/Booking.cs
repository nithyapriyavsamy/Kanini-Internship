using System.ComponentModel.DataAnnotations;

namespace BookingManagement.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public int H_Id { get; set; }
        public int R_No { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
    }
}
