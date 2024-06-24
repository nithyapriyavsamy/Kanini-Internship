using UserManagement.Models.DTO;

namespace UserManagement.Interfaces
{
    public interface ITokenGenerate
    {
        public string GenerateToken(UserDTO user);
    }
}
