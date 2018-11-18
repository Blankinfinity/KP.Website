using System;
using System.Collections.Generic;
using System.Text;
using KP.Domain.Entities.Models;

namespace KP.Domain.Entities.Extensions
{
    public static class OwnerExtensions
    {
        public static void Map(this Owner dbOwner, Owner owner)
        {
            dbOwner.Name = owner.Name;
            dbOwner.Address = owner.Address;
            dbOwner.DateOfBirth = owner.DateOfBirth;
        }
    }
}
