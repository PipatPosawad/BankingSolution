using System.ComponentModel.DataAnnotations;

namespace Banking.WebApi.Dtos
{
    public class DepositAccountDto
    {
        [Required]
        public string AccountNumber { get; set; }

        [Required]
        [PositiveNumberAttribute]
        public decimal Amount { get; set; }
    }
}
