using HotelManagement.Models;
using HotelManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        HotelService _service;
        public HotelController(HotelService service)
        {
            _service = service;
        }
        [HttpGet("All")]
        [Authorize]
        public ActionResult<List<Hotel>> GetAll()
        {
            List<Hotel> list = new List<Hotel>();
            list = _service.GetAll().ToList();
            if(list != null && list.Count > 0)
            {
                return Ok(list);
            }
            return BadRequest("Hotels are not available");
        }
        [HttpGet("one")]
        [Authorize]
        public ActionResult<Hotel> Get(string name,string city)
        {
            Hotel hotel = new Hotel();
            hotel = _service.Get(name, city);
            if(hotel != null)
            {
                return Ok(hotel);
            }
            return BadRequest("There is no such hotel available");
        }
        [HttpPost]
        [Authorize]
        public ActionResult<Hotel> Add(Hotel hotel)
        {
            Hotel hot=new Hotel();
            hot=_service.Add(hotel);
            if(hot != null)
            {
                return Ok(hot);
            }
            return BadRequest("Cannot add this hotel");
        }
        [HttpDelete]
        [Authorize]
        public ActionResult<Hotel> Remove(string name,string city)
        {
            Hotel hot = new Hotel();
            hot = _service.Remove(name,city);
            if (hot != null)
            {
                return Ok(hot);
            }
            return BadRequest("Cannot remove this hotel");
        }
        [HttpPut]
        [Authorize]
        public ActionResult<Hotel> Update(string name,string city,Hotel hotel)
        {
            Hotel hot = new Hotel();
            hot=_service.Update(name, city, hotel);
            if(hot != null)
            {
                return Ok(hot);
            }
            return BadRequest("There is no such position to update");
        }
    }
}
