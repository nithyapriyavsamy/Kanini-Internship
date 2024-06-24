using BookingManagement.Models;
using BookingManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BookingService _service;
        public BookingController(BookingService service)
        {
            _service = service;
        }
        [HttpPost]
        [Authorize]
        public ActionResult<Booking> Book(Booking booking)
        {
            Booking book = new Booking();
            book=_service.Add(booking);
            if(book != null)
            {
                return Ok(book);
            }
            return BadRequest("Not available for Booking");
        }
        [HttpDelete]
        [Authorize]
        public ActionResult<Booking> cancel(int id)
        {
            Booking book = new Booking();
            book = _service.Remove(id);
            if (book != null)
            {
                return Ok(book);
            }
            return BadRequest("Can't cancel Booking");
        }
    }
}
