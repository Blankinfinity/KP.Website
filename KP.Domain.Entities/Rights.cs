using System;
using System.Collections.Generic;
using System.Text;

namespace KP.Domain.Entities
{
    public class Rights
    {
        public string Name { get; set; }
        public IEnumerable<Roles> Roles { get; set; }
    }
}
