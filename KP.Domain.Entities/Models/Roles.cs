using System.Collections.Generic;

namespace KP.Domain.Entities.Models
{
    public class Roles
    {
        public string Name { get; set; }
        public IEnumerable<Users> Users { get; set; }
    }
}
