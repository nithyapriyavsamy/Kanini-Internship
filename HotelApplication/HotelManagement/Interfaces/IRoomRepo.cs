namespace HotelManagement.Interfaces
{
    public interface IRoomRepo<R,RD,I,S>
    {
        R Add(RD item);
        R Remove(S H_name, I R_No);
        R Get(S H_name,I R_No);
        ICollection<R> GetAll(S H_name);
        R Update(S H_name, I R_No, RD item);
    }
}
