namespace Banking.WebApi.Dtos
{
    public class DepositAccountResultDto
    {
        public string AccountNumber { get; set; }

        public decimal Balance { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
