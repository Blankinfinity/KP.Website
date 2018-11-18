using System;
using System.Collections.Generic;
using System.Text;

namespace KP.Domain.Entities.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
