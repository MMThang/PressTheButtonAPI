﻿namespace PressTheButtonAPI.DTOs.UserDTOs
{
    public class CreateUserDTO
    {
        
        public string Name { get; set; }

        public string Password { get; set; }
        
        public string recheckPassword { get; set; }
    }
}
