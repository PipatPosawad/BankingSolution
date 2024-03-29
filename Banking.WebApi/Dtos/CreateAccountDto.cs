using System.ComponentModel.DataAnnotations;

namespace Banking.WebApi.Dtos
{
    public class CreateAccountDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [PositiveNumberAttribute]
        public decimal Amount { get; set; }
    }
}
