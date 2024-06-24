using HotelManagement.Models;
using HotelManagement.Models.DTO;
using HotelManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        RoomService _service;
        public RoomController(RoomService roomService)
        {
            _service = roomService;
        }
        [HttpGet("All")]
        [Authorize]
        public ActionResult<List<Room>> GetAll(string name)
        {
            List<Room> list = new List<Room>();
            list=_service.GetAll(name).ToList();
            if(list.Count != 0&&list!=null)
            {
                return Ok(list);
            }
            return BadRequest("Rooms not available");
        }
        [HttpGet("one")]
        [Authorize]
        public ActionResult<Room> Get(string name,int r_no)
        {
            Room room = new Room();
            room=_service.Get(name, r_no);
            if(room!=null)
            {
                return Ok(room);
            }
            return BadRequest("There is no such room available");
        }
        [HttpDelete]
        [Authorize]
        public ActionResult<Room> Remove(string name,int r_no)
        {
            Room room=new Room();
            room = _service.Remove(name, r_no);
            if(room != null)
            {
                return Ok(room);
            }
            return BadRequest("Can't remove that room");
        }
        [HttpPost]
        [Authorize]
        public ActionResult<Room> Add(RoomDTO room)
        {
            Room room1 = new Room();
            room1= _service.Add(room);
            if( room1!=null)
            {
                return Ok(room1);
            }
            return BadRequest("can't add the room");
        }
        [HttpPut]
        [Authorize]
        public ActionResult<Room> Update(string name,int r_no,RoomDTO room)
        {
            Room room1=new Room();
            room1=_service.Update(name, r_no,room);
            if (room1 != null)
            {
                return Ok(room1);
            }
            return BadRequest("Can't update this room");
        }
    }
}
