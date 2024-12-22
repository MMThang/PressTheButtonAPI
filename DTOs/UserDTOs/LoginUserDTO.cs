using System.ComponentModel.DataAnnotations;

namespace PressTheButtonAPI.DTOs.UserDTOs
{
    public class LoginUserDTO
    {
        
        public string Name { get; set; }
        
        public string Password { get; set; }
    }
}
