using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public class Hotel
    {
        [Key]
        public int H_Id { get; set; }
        public string H_Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Rating { get; set; }

    }
}
