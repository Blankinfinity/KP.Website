using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using KP.Domain.Contracts;
using KP.Domain.Entities;
using KP.Domain.Entities.ExtendedModels;
using KP.Domain.Entities.Extensions;
using KP.Domain.Entities.Models;
using KP.Infrastructure.Connections;

namespace KP.Domain.Data
{
    public class OwnerRepository : BaseRepository, IOwnerRepository
    {

        // Stored Proc returns values.
        //https://docs.microsoft.com/en-us/sql/relational-databases/stored-procedures/return-data-from-a-stored-procedure
        //

        public OwnerRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public async Task<IEnumerable<Owner>> GetAllOwners()
        {
            const string sql = "SELECT * FROM [dbo].[Owner] ORDER BY [Owner].[Name] ASC";
            var result = await Query<Owner>(sql);
            return result;
        }

        public async Task<Owner> GetOwnerById(Guid ownerId)
        {
            const string sql = "SELECT * FROM [dbo].[Owner] WHERE [Owner].[OwnerId] = @ownerId";
            var result = await QuerySingle<Owner>(sql, new {ownerId});
            return result;
        }

        public async Task<OwnerExtended> GetOwnerWithDetails(Guid ownerId)
        {
            var owner = await GetOwnerById(ownerId);

            const string sql = "SELECT * FROM [dbo].[Account] WHERE [Account].[OwnerId] = @ownerId;";

            var accounts = await Query<Account>(sql, new {ownerId});

            var ownerExtended = new OwnerExtended()
            {
                Id = owner.Id,
                Address = owner.Address,
                DateOfBirth = owner.DateOfBirth,
                Name = owner.Name,
                Accounts = accounts
            };

            return ownerExtended;
        }

        public async Task CreateOwner(Owner owner)
        {
            owner.Id = Guid.NewGuid();
            var sql = "INSERT INTO [dbo].[Owner] VALUES (@OwnerId, @Name, @DateOfBirth, @Address)";
            await Execute(sql, new { OwnerId = owner.Id, owner.Name, owner.DateOfBirth, owner.Address}, CommandType.Text);
        }

        public async Task UpdateOwner(Owner dbOwner, Owner owner)
        {
            dbOwner.Map(owner);
            var sql = "UPDATE [dbo].[Owner] SET Address=@Address, DateOfBirth=@DateOfBirth, Name=@Name WHERE OwnerId = @OwnerId";
            await Execute(sql, new {OwnerId = dbOwner.Id, dbOwner.Name, dbOwner.DateOfBirth, dbOwner.Address}, CommandType.Text);
        }

        public async Task DeleteOwner(Owner owner)
        {
            var sql = "DELETE FROM [dbo].[Owner] WHERE OwnerId = @OwnerId";
            await Execute(sql, new {OwnerId = owner.Id}, CommandType.Text);
        }
    }
}
