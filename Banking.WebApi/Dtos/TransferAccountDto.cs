using System.ComponentModel.DataAnnotations;

namespace Banking.WebApi.Dtos
{
    public class TransferAccountDto
    {
        [Required]
        public string FromAccountNumber { get; set; }

        [Required]
        public string ToAccountNumber { get; set; }

        [Required]
        [PositiveNumber]
        public decimal Amount { get; set; }
    }
}
