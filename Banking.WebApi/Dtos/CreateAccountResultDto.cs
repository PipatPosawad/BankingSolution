using System.ComponentModel.DataAnnotations;

namespace Banking.WebApi.Dtos
{
    public class CreateAccountResultDto
    {
        public string AccountNumber { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Balance { get; set; }
    }
}
