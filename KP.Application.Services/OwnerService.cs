using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KP.Application.Contracts;
using KP.Domain.Contracts;
using KP.Domain.Entities;
using KP.Domain.Entities.ExtendedModels;
using KP.Domain.Entities.Models;

namespace KP.Application.Services
{
    public class OwnerService: IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        // Stored Proc returns values.
        //https://docs.microsoft.com/en-us/sql/relational-databases/stored-procedures/return-data-from-a-stored-procedure
        //

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public async Task<IEnumerable<Owner>> GetAllOwners()
        {
            return await _ownerRepository.GetAllOwners();
        }

        public async Task<Owner> GetOwnerById(Guid ownerId)
        {
            return await _ownerRepository.GetOwnerById(ownerId);
        }

        public async Task<OwnerExtended> GetOwnerWithDetails(Guid ownerId)
        {
            return await _ownerRepository.GetOwnerWithDetails(ownerId);
        }

        public async Task CreateOwner(Owner owner)
        {
            await _ownerRepository.CreateOwner(owner);
        }

        public async Task UpdateOwner(Owner dbOwner, Owner owner)
        {
            await _ownerRepository.UpdateOwner(dbOwner, owner);
        }

        public async Task DeleteOwner(Owner owner)
        {
            await _ownerRepository.DeleteOwner(owner);
        }
    }
}
