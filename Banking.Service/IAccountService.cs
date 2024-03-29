using Banking.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Service
{
    public interface IAccountService
    {
        Task<Account> CreateAccountAsync(CreateAccount createAccount);

        Account DepositAccount(DepositAccount depositAccount);

        TransferResult TransferAccount(TransferAccount transferAccount);
    }
}
