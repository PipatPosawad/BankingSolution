namespace Banking.WebApi.Dtos
{
    public class TransferAccountResultDto
    {
        public string FromAccountNumber { get; set; }

        public string ToAccountNumber { get; set; }

        public decimal Amount { get; set; }

        public decimal FromAccountNumberBalance { get; set; }
    }
}
