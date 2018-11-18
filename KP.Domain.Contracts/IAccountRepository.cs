using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KP.Domain.Entities.Models;

namespace KP.Domain.Contracts
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> AccountsByOwner(Guid ownerId);
    }
}
