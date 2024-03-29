using Banking.Repository;
using Banking.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountNumberGenerator _numberGenerator;
        private readonly IAccountRepository _repository;

        public AccountService(IAccountNumberGenerator accountNumberGenerator,
            IAccountRepository accountRepository) 
        {
            _repository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _numberGenerator = accountNumberGenerator ?? throw new ArgumentNullException(nameof(accountNumberGenerator));
        }

        public async Task<Account> CreateAccountAsync(CreateAccount createAccount)
        {
            var accountNumber = await _numberGenerator.GenerateAccountNumberAsync();

            var newAccount = new Account()
            {
                AccountNumber = accountNumber,
                Id = Guid.NewGuid(),
                FirstName = createAccount.FirstName,
                LastName = createAccount.LastName,
                Balance = createAccount.Amount
            };

            var result = _repository.Add(newAccount);

            if (result)
                return newAccount;
            else
                return null;
        }

        public Account DepositAccount(DepositAccount depositAccount)
        {
            var account = _repository.Get(depositAccount.AccountNumber);

           account.Balance += (depositAccount.Amount - Fee(depositAccount.Amount));

            _repository.UpdateBalance(account.AccountNumber, account.Balance);

            return account;
        }

        private decimal Fee(decimal cost)
        {
            return cost * (decimal)0.1 / 100;
        }

        public TransferResult TransferAccount(TransferAccount transferAccount)
        {
            var from = _repository.Get(transferAccount.FromAccountNumber);
            var to = _repository.Get(transferAccount.ToAccountNumber);

            from.Balance -= transferAccount.Amount;
            to.Balance += transferAccount.Amount;

            _repository.UpdateBalance(from.AccountNumber, from.Balance);
            _repository.UpdateBalance(to.AccountNumber, to.Balance);

            return new TransferResult()
            {
                Amount = transferAccount.Amount,
                ToAccountNumber = transferAccount.ToAccountNumber,
                FromAccountNumber = transferAccount.FromAccountNumber,
                FromAccountNumberBalance = from.Balance
            };
        }
    }
}
