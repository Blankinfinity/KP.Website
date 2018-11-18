using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KP.Domain.Entities;
using KP.Domain.Entities.ExtendedModels;
using KP.Domain.Entities.Models;

namespace KP.Domain.Contracts
{
    public interface IOwnerRepository
    {
        Task<IEnumerable<Owner>> GetAllOwners();
        Task<Owner> GetOwnerById(Guid ownerId);
        Task<OwnerExtended> GetOwnerWithDetails(Guid ownerId);
        Task CreateOwner(Owner owner);
        Task UpdateOwner(Owner dbOwner, Owner owner);
        Task DeleteOwner(Owner owner);
    }
}
