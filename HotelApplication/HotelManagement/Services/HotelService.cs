using HotelManagement.Interfaces;
using HotelManagement.Models;

namespace HotelManagement.Services
{
    public class HotelService
    {
        IHotelRepo<Hotel, string> _repo;
        public HotelService(IHotelRepo<Hotel,string> repo)
        {
            _repo = repo;
        }
        public ICollection<Hotel> GetAll()
        {
            return _repo.GetAll();
        }
        public Hotel Get(string name,string city)
        {
            return _repo.Get(name, city);
        }
        public Hotel Add(Hotel hotel)
        {
            return _repo.Add(hotel);
        }
        public Hotel Remove(string name,string city)
        {
            return _repo.Remove(name, city);
        }
        public Hotel Update(string name,string city, Hotel hotel)
        {
            return _repo.Update(name, city, hotel);
        }
    }
}
