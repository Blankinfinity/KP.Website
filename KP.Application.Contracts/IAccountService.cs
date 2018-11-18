using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KP.Domain.Entities.Models;

namespace KP.Application.Contracts
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> AccountsByOwner(Guid ownerId);
    }
}
