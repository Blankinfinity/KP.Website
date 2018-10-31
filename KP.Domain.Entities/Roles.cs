using System;
using System.Collections.Generic;
using System.Text;

namespace KP.Domain.Entities
{
    public class Roles
    {
        public string Name { get; set; }
        public IEnumerable<Users> Users { get; set; }
    }
}
