using System;
using System.Collections.Generic;
using System.Text;

namespace KP.Domain.Entities
{
    public class Categories
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Parent { get; set; }
    }
}
