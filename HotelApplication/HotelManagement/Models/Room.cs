using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models
{
    public class Room
    {
        [Key] 
        public int R_Id { get; set; }

        [ForeignKey("Hotel")]
        public int Hotel_Id { get; set; }
        public Hotel Hotel { get; set; }
        public int Room_No { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
    }
}
