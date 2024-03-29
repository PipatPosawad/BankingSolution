using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Service
{
    public interface IAccountNumberGenerator
    {
        Task<string> GenerateAccountNumberAsync();
    }
}
