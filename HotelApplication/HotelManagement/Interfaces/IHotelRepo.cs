namespace HotelManagement.Interfaces
{
    public interface IHotelRepo<H,S>
    {
        H Add(H item);
        H Remove(S name, S city);
        H Update(S name, S city, H item);
        H Get(S name, S city);
        ICollection<H> GetAll();
    }
}
