using System.Diagnostics;
using UserManagement.Interfaces;
using UserManagement.Models;

namespace UserManagement.Services
{
    public class UserRepo : IUserRepo<User,string>
    {
        private readonly UserContext _context;

        public UserRepo()
        {
            _context = new UserContext();
        }
        public User Add(User item)
        {
            try
            {
                _context.Users.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(item);
            }
            return null;
        }

        public User Get(string key)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == key);
            return user;
        }

    }
}
