using Banking.Service.Model;
using Banking.WebApi.Dtos;

namespace Banking.WebApi.Extensions
{
    public static class AccountExtensions
    {
        public static CreateAccount ToCreateAccount(this CreateAccountDto createAccountDto)
        {
            return new CreateAccount()
            {
                FirstName = createAccountDto.FirstName,
                LastName = createAccountDto.LastName,
                Amount = createAccountDto.Amount,
            };
        }

        public static DepositAccount ToDepositAccount(this DepositAccountDto depositAccountDto)
        {
            return new DepositAccount()
            {
                AccountNumber = depositAccountDto.AccountNumber,
                Amount = depositAccountDto.Amount
            };
        }

        public static DepositAccountResultDto ToDepositAccountResultDto(this Account account)
        {
            return new DepositAccountResultDto()
            {
                AccountNumber = account.AccountNumber,
                Amount = account.Balance
            };
        }

        public static TransferAccount ToTransferAccount(this TransferAccountDto transferAccountDto)
        {
            return new TransferAccount()
            {
                FromAccountNumber = transferAccountDto.FromAccountNumber,
                ToAccountNumber = transferAccountDto.ToAccountNumber,
                Amount = transferAccountDto.Amount
            };
        }

        public static TransferAccountResultDto ToTransferAccountResultDto(this TransferResult transferResult)
        {
            return new TransferAccountResultDto()
            {
                Amount = transferResult.Amount,
                ToAccountNumber = transferResult.ToAccountNumber,
                FromAccountNumber = transferResult.FromAccountNumber,
                FromAccountNumberBalance = transferResult.FromAccountNumberBalance
            };
        }
    }
}
