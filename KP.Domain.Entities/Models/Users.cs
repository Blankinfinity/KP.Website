using System;

namespace KP.Domain.Entities.Models
{
    public class Users
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime LastLoginTime { get; set; }
    }
}
