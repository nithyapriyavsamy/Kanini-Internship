using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models.DTO
{
    public class RoomDTO
    {
        public int R_Id { get; set; }
        public string Hotel_Name { get; set; }
        public int Room_No { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
    }
}
