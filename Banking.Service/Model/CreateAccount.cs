using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Service.Model
{
    public class CreateAccount
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Amount { get; set; }
    }
}
