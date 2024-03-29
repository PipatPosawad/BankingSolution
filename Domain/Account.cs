namespace Banking.Service.Model
{
    public class Account
    {
        public string AccountNumber { get; set; }

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Balance { get; set; }
    }
}
