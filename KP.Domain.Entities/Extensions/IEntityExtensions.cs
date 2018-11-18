using System;
using System.Collections.Generic;
using System.Text;
using KP.Domain.Entities.Interfaces;

namespace KP.Domain.Entities.Extensions
{
    public static class IEntityExtensions
    {
        public static bool IsObjectNull(this IEntity entity)
        {
            return entity == null;
        }
        public static bool IsEmptyObject(this IEntity entity)
        {
            return entity.Id.Equals(Guid.Empty);
        }
    }
}
