using HotelManagement.Interfaces;
using HotelManagement.Models;
using System.Xml.Linq;

namespace HotelManagement.Services
{
    public class HotelRepo : IHotelRepo<Hotel, string>
    {
        HotelContext _context;
        public HotelRepo()
        {
            _context = new HotelContext();
        }
        public Hotel Add(Hotel item)
        {
            List<Hotel> hotels = new List<Hotel>();
            int flag = 0;
            hotels = GetAll().ToList();
            foreach (var hotel in hotels)
            {
                if (hotel.H_Name == item.H_Name && hotel.City == item.City)
                {
                    flag=1;
                }
            }
            if (flag == 0)
            {
                _context.Add(item);
                _context.SaveChanges();
                item.H_Id = GetLatestId();
                return item;
            }
            return null;
        }

        public ICollection<Hotel> GetAll()
        {
            List<Hotel> hotels = new List<Hotel>();
            hotels = _context.Hotels.ToList();
            return hotels;
        }

        public Hotel Get(string name, string city)
        {
            List<Hotel> hotels = new List<Hotel>();
            hotels = GetAll().ToList();
            foreach (var hotel in hotels)
            {
                if (hotel.H_Name == name && hotel.City == city)
                {
                    return hotel;
                }
            }
            return null;
        }

        public Hotel Remove(string name, string city)
        {
            Hotel hot = new Hotel();
            List<Hotel> hotels = new List<Hotel>();
            hotels = GetAll().ToList();
            foreach(var hotel in hotels)
            {
                if (hotel.H_Name == name && hotel.City == city)
                {
                    hot.H_Id=hotel.H_Id;
                    hot.H_Name=hotel.H_Name;
                    hot.City=hotel.City;
                    hot.Country=hotel.Country;
                    hot.Rating=hotel.Rating;
                    _context.Remove(hotel);
                    _context.SaveChanges();
                    return hot;
                }
            }
            return null;
        }

        public Hotel Update(string name, string city, Hotel hotel)
        {
            List<Hotel> hotels = new List<Hotel>();
            hotels = GetAll().ToList();
            foreach (var hot in hotels)
            {
                if (hot.H_Name == name && hot.City == city)
                {
                    hot.H_Name = hotel.H_Name;
                    hot.City = hotel.City;
                    hot.Country = hotel.Country;
                    hot.Rating = hotel.Rating;
                    _context.SaveChanges();
                    return hot;
                }
            }
            return null;
        }
        public int GetLatestId()
        {
            List<Hotel> hotels = new List<Hotel>();
            hotels = _context.Hotels.ToList();
            int id = 0;
            foreach (var hot in hotels)
            {
                id = hot.H_Id;
            }
            return id;
        }
    }
}
