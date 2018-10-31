using System;

namespace KP.Domain.Entities
{
    public class Users
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime LastLoginTime { get; set; }
    }
}
