using Banking.Repository;
using Banking.Service.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Service.Test
{
    public class AccountServiceTests
    {
        private readonly Mock<IAccountNumberGenerator> _mockAccountNumberGenerator;
        private readonly Mock<IAccountRepository> _mockAccountRepository;

        private readonly AccountService _accountService;

        public AccountServiceTests() 
        {
            _mockAccountNumberGenerator = new Mock<IAccountNumberGenerator>();
            _mockAccountRepository = new Mock<IAccountRepository>();

            _accountService = new AccountService(_mockAccountNumberGenerator.Object,
                _mockAccountRepository.Object);
        }

        [Fact]
        public async Task CreateAccountAsync_ReturnsNewAccount_WhenOperationIsSuccesful()
        {

        }

        [Fact]
        public async Task DepositAccount_ReturnsDepositResult_WhenOperationIsSuccesful()
        {
            // Arrange
            var accountNumber = "OIJOIFDS";
            var amount = 1000;
            var balance = 0;
            var fee = 1;
            var balanceAfterDeposit = balance + amount - fee;

            var depositAccount = new DepositAccount()
            {
                AccountNumber = accountNumber,
                Amount = amount
            };

            var account = new Account()
            {
                AccountNumber = accountNumber,
                Balance = balance
            };

            _mockAccountRepository.Setup(x => x.Get(It.IsAny<string>()))
                .Returns(account);

            // Act
            var result = _accountService.DepositAccount(depositAccount);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(accountNumber, result.AccountNumber);
            Assert.Equal(balanceAfterDeposit, result.Balance);
        }

        [Fact]
        public async Task TransferAccount_ReturnsTransferResult_WhenOperationIsSuccesful()
        {
            // Arrange
            var fromAccountNumber = "DFSFS";
            var toAccountNumber = "REWREW";
            var amount = 5612;
            var fromAccountBalance = 10000;
            var fromAccountBalanceAfterTransfer = fromAccountBalance - amount;

            var toAccountBalance = 0;
            var toAccountBalanceAfterTransfer = toAccountBalance + amount;

            var transferAccount = new TransferAccount()
            {
                FromAccountNumber = fromAccountNumber,
                ToAccountNumber = toAccountNumber,
                Amount = amount
            };

            var fromAccount = new Account()
            {
                AccountNumber = fromAccountNumber,
                Balance = fromAccountBalance
            };

            var toAccount = new Account()
            {
                AccountNumber = toAccountNumber,
                Balance = toAccountBalance
            };

            _mockAccountRepository.Setup(x => x.Get(fromAccountNumber))
                .Returns(fromAccount);
            _mockAccountRepository.Setup(x => x.Get(toAccountNumber))
                .Returns(toAccount);

            // Act
            var result = _accountService.TransferAccount(transferAccount);

            // Assert
            Assert.NotNull(result);

            Assert.Equal(fromAccountNumber, result.FromAccountNumber);
            Assert.Equal(toAccountNumber, result.ToAccountNumber);
            Assert.Equal(amount, result.Amount);
            Assert.Equal(fromAccountBalanceAfterTransfer, result.FromAccountNumberBalance);

            _mockAccountRepository.Verify(x => x.UpdateBalance(fromAccountNumber, fromAccountBalanceAfterTransfer), Times.Once);
            _mockAccountRepository.Verify(x => x.UpdateBalance(toAccountNumber, toAccountBalanceAfterTransfer), Times.Once);
        }
    }
}
