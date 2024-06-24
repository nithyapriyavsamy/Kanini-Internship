using BookingManagement.Interfaces;
using BookingManagement.Models;
using System.Diagnostics;

namespace BookingManagement.Services
{
    public class BookingRepo : IBookingRepo<Booking, int>
    {
        BookingContext _context;
        public BookingRepo()
        {
            _context=new BookingContext();
        }
        public Booking Add(Booking item)
        {
            try
            {
                _context.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return null;
        }

        public Booking Remove(int id)
        {
            List<Booking> bookings = new List<Booking>();
            bookings=_context.Bookings.ToList();
            foreach (Booking booking in bookings)
            {
                if (booking.Id == id)
                {
                    bookings.Remove(booking);
                    _context.SaveChanges();
                    return booking;
                }
            }
            return null;
        }
    }
}
