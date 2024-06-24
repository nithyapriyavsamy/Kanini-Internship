using BookingManagement.Interfaces;
using BookingManagement.Models;

namespace BookingManagement.Services
{
    public class BookingService
    {
        private readonly IBookingRepo<Booking, int> _repo;
        public BookingService(IBookingRepo<Booking, int> repo)
        {
            _repo = repo;
        }
        public Booking Add(Booking booking)
        {
            return _repo.Add(booking);
        }
        public Booking Remove(int id)
        {
            return _repo.Remove(id);
        }
    }
}
