using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KP.Application.Contracts;
using KP.Domain.Contracts;
using KP.Domain.Entities.Models;

namespace KP.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<IEnumerable<Account>> AccountsByOwner(Guid ownerId)
        {
            return await _accountRepository.AccountsByOwner(ownerId);
        }
    }
}
