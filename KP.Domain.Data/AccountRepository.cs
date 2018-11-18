using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KP.Domain.Contracts;
using KP.Domain.Entities.Models;
using KP.Infrastructure.Connections;

namespace KP.Domain.Data
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        // Stored Proc returns values.
        //https://docs.microsoft.com/en-us/sql/relational-databases/stored-procedures/return-data-from-a-stored-procedure
        //

        public AccountRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public async Task<IEnumerable<Account>> AccountsByOwner(Guid ownerId)
        {
            const string sql = "SELECT * FROM [dbo].[Account] WHERE [Account].[OwnerId] = @ownerId";
            var result = await Query<Account>(sql, new { ownerId });
            return result;
        }
    }
}
