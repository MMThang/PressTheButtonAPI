using PressTheButtonAPI.Entities;

namespace PressTheButtonAPI.Interfaces
{
    public interface IJwtRepository
    {
        public string GenerateJwtToken(User user);
        public bool CheckToken(string token);
    }
}
