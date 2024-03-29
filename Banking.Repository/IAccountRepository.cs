using Banking.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Repository
{
    public interface IAccountRepository
    {
        bool Add(Account account);

        Account Get(string accountNumber);

        void UpdateBalance(string accountNumber, decimal money);
    }
}
