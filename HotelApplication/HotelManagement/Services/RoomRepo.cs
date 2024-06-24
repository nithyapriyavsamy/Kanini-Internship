using HotelManagement.Interfaces;
using HotelManagement.Models;
using HotelManagement.Models.DTO;

namespace HotelManagement.Services
{
    public class RoomRepo : IRoomRepo<Room,RoomDTO, int,string>
    {
        HotelContext _context;
        public RoomRepo()
        {
            _context = new HotelContext();
        }

        public Room Add(RoomDTO item)
        {
            int id = GetHId(item.Hotel_Name);
            Room room1 = new Room();
            int flag = 0;
            if (id != -1)
            {
                List<Room> list = new List<Room>();
                list = GetAll().ToList();
                foreach(var room in list)
                {
                    if(room.Hotel_Id== id && room.Room_No == item.Room_No)
                    {
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    room1.Hotel_Id= id;
                    room1.Room_No = item.Room_No;
                    room1.Price= item.Price;
                    room1.Type= item.Type;
                    _context.Add(room1);
                    _context.SaveChanges();
                    return room1;
                }
            }
            return null;
        }

        public Room Get(string H_name, int R_No)
        {
            int id = GetHId(H_name);
            List<Room> list = new List<Room>();
            list = _context.Rooms.ToList();
            foreach(var room in list)
            {
                if(room.Hotel_Id== id && room.Room_No == R_No)
                {
                    return room;
                }
            }
            return null;
        }

        public ICollection<Room> GetAll()
        {
            List<Room> list = new List<Room>();
            list = _context.Rooms.ToList();
            return list;
        }

        public ICollection<Room> GetAll(string H_name)
        {
            int id = GetHId(H_name);
            if (id != -1)
            {
                List<Room> list = new List<Room>();
                list = _context.Rooms.ToList();
                List<Room> result = new List<Room>();
                foreach (Room room in list)
                {
                    if (room.Hotel_Id == id)
                    {
                        result.Add(room);
                    }
                }
                return result;
            }
            return null;
        }

        public Room Remove(string H_name, int R_No)
        {
            int id = GetHId(H_name);
            Room rm = new Room();
            if (id != -1)
            {
                List<Room> list = new List<Room>();
                list = _context.Rooms.ToList();
                foreach (var room in list)
                {
                    if (room.Hotel_Id == id && room.Room_No == R_No)
                    {
                        rm.R_Id = room.R_Id;
                        rm.Hotel_Id= room.Hotel_Id;
                        rm.Room_No= room.Room_No;
                        rm.Price= room.Price;
                        rm.Type= room.Type;
                        _context.Remove(room);
                        _context.SaveChanges();
                        return room;
                    }
                }
            }
            return null;
        }

        public Room Update(string H_name, int R_No, RoomDTO item)
        {
            int id = GetHId(H_name);
            int id1 = GetHId(item.Hotel_Name);
            if(id != -1 && id!=-1)
            {
                List<Room> list = new List<Room>();
                list = _context.Rooms.ToList();
                foreach (var room in list)
                {
                    if (room.Hotel_Id == id && room.Room_No == R_No)
                    {
                        room.Hotel_Id = id1;
                        room.Room_No = item.Room_No;
                        room.Price = item.Price;
                        room.Type = item.Type;
                        _context.SaveChanges();
                        return room;
                    }
                }
            }
            return null;
        }
        public int GetHId(string H_name)
        {
            List<Hotel > list = new List<Hotel>();
            list=_context.Hotels.ToList();
            foreach(Hotel hotel in list)
            {
                if(hotel.H_Name== H_name)
                {
                    return hotel.H_Id;
                }
            }
            return -1;
        }
    }
}
