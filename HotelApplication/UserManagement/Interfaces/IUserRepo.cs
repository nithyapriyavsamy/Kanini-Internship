namespace UserManagement.Interfaces
{
    public interface IUserRepo<U,K>
    {
        U Add(U item);
        U Get(K key);
    }
}
