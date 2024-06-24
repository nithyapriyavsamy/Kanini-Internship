using HotelManagement.Interfaces;
using HotelManagement.Models;
using HotelManagement.Models.DTO;

namespace HotelManagement.Services
{
    public class RoomService
    {
        IRoomRepo<Room,RoomDTO,int,string> _repo;
        public RoomService(IRoomRepo<Room, RoomDTO, int, string> roomRepo)
        {
            _repo = roomRepo;
        }
        public ICollection<Room> GetAll(string name)
        {
            return _repo.GetAll(name);
        }
        public Room Get(string name,int r_no)
        {
            return _repo.Get(name, r_no);
        }
        public Room Update(string  name,int r_no,RoomDTO item)
        {
            return _repo.Update(name, r_no, item);
        }
        public Room Remove(string name,int r_no)
        {
            return _repo.Remove(name, r_no);
        }
        public Room Add(RoomDTO room)
        {
            return _repo.Add(room);
        }
    }
}
