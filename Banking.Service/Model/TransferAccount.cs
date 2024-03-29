using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Service.Model
{
    public class TransferAccount
    {
        public string FromAccountNumber {  get; set; }

        public string ToAccountNumber { get; set; }

        public decimal Amount { get; set; }
    }
}
