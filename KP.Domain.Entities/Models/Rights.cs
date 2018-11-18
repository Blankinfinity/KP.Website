using System.Collections.Generic;

namespace KP.Domain.Entities.Models
{
    public class Rights
    {
        public string Name { get; set; }
        public IEnumerable<Roles> Roles { get; set; }
    }
}
