﻿namespace Api_Service.Common.Auth
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
    }
}
