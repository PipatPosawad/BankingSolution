using Banking.Service.Model;
using Microsoft.Extensions.Logging;

namespace Banking.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly List<Account> storage;

        private readonly ILogger _logger;

        public AccountRepository(ILogger logger)
        {
            storage = new List<Account>();

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public bool Add(Account account)
        {
            _logger.LogInformation("Create new account {0}", account.AccountNumber);

            if (storage.Any(x => x.AccountNumber == account.AccountNumber))
            {
                return false;
            }

            storage.Add(account);
            return true;
        }

        public Account Get(string accountNumber)
        {
            return storage.FirstOrDefault(x => x.AccountNumber == accountNumber);
        }

        public void UpdateBalance(string accountNumber, decimal money)
        {
            _logger.LogInformation("Deposit account {0} for {1}", accountNumber, money.ToString());

            var account = Get(accountNumber);
            storage.Remove(account);

            account.Balance = money;
            storage.Add(account);
        }
    }
}
