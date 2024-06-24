namespace BookingManagement.Interfaces
{
    public interface IBookingRepo<B,K>
    {
        B Add(B item);
        B Remove(K id);
    }
}
