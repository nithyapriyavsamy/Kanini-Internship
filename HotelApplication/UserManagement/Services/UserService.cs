using System.Security.Cryptography;
using System.Text;
using UserManagement.Interfaces;
using UserManagement.Models;
using UserManagement.Models.DTO;

namespace UserManagement.Services
{
    public class UserService
    {
        private IUserRepo<User,string> _repo;
        private ITokenGenerate _tokenService;

        public UserService(IUserRepo<User, string> repo, ITokenGenerate tokenGenerate)
        {
            _repo = repo;
            _tokenService = tokenGenerate;
        }
        public UserDTO Login(LoginDTO loginDTO)
        {
            UserDTO user = null;
            var userData = _repo.Get(loginDTO.Username);
            if (userData != null)
            {
                var hmac = new HMACSHA512(userData.HashKey);
                var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
                for (int i = 0; i < userPass.Length; i++)
                {
                    if (userPass[i] != userData.Password[i])
                        return null;
                }
                user = new UserDTO();
                user.Username = userData.Username;
                user.Name = userData.Name;
                user.Age= userData.Age;
                user.PhoneNo= userData.PhoneNo;
                user.Token = _tokenService.GenerateToken(user);
            }
            return user;
        }
        public UserDTO Register(RegisterDTO registerDTO)
        {
            User user = new User();
            UserDTO user1 = new UserDTO();
            var hmac = new HMACSHA512();
            user.Username= registerDTO.Username;
            user.Name= registerDTO.Name;
            user.Age= registerDTO.Age;
            user.PhoneNo = registerDTO.PhoneNo;
            user.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password));
            user.HashKey = hmac.Key;
            var resultUser = _repo.Add(user);
            if (resultUser != null)
            {
                user1.Username = resultUser.Username;
                user1.Name = resultUser.Name;
                user1.Age = resultUser.Age;
                user1.PhoneNo= resultUser.PhoneNo;
                user1.Token = _tokenService.GenerateToken(user1);
            }
            return user1;
        }
    }
}
