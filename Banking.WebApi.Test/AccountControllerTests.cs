using Banking.Service;
using Banking.Service.Model;
using Banking.WebApi.Controllers;
using Banking.WebApi.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Reflection;
using System.Security.Principal;

namespace Banking.WebApi.Test
{
    public class AccountControllerTests
    {
        private readonly Mock<IAccountService> _mockAccountService;

        private readonly AccountController _controller;

        public AccountControllerTests()
        {
            _mockAccountService = new Mock<IAccountService>();

            _controller = new AccountController(_mockAccountService.Object);
        }

        [Fact]
        public async Task PostAccountAsync_ReturnsOk_WhenOperationIsSuccesful()
        {
            // Arrange
            var amount = 1000;
            var firstName = "John";
            var lastName = "Doe";
            var createAccountDto = new Dtos.CreateAccountDto()
            {
                Amount = amount,
                FirstName = firstName,
                LastName = lastName
            };

            var account = new Account()
            {
                AccountNumber = "ACBD",
                Balance = amount,
                FirstName = firstName,
                LastName = lastName
            };

            _mockAccountService.Setup(x => x.CreateAccountAsync(It.IsAny<CreateAccount>()))
                .ReturnsAsync(account);

            // Act
            var actual = await _controller.PostAccountAsync(createAccountDto) as OkObjectResult;

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(StatusCodes.Status200OK, actual.StatusCode);

            var model = actual.Value as CreateAccountResultDto;
            Assert.Equal(amount, model.Balance);
            Assert.Equal(account.AccountNumber, model.AccountNumber);
            Assert.Equal(firstName, model.FirstName);
            Assert.Equal(lastName, model.LastName);
        }

        [Fact]
        public void Deposit_ReturnsOk_WhenOperationIsSuccesful()
        {
            // Arrange
            var accountNumber = "ADFS";

            var depositAccountDto = new DepositAccountDto()
            {
                AccountNumber = accountNumber,
                Amount = 555
            };

            var account = new Account()
            {
                FirstName = "John",
                LastName = "Doe",
                AccountNumber = accountNumber,
                Balance = 5554895
            };

            _mockAccountService.Setup(x => x.DepositAccount(It.IsAny<DepositAccount>()))
                .Returns(account);

            // Act
            var actual = _controller.Deposit(depositAccountDto) as OkObjectResult;

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(StatusCodes.Status200OK, actual.StatusCode);

            var model = actual.Value as DepositAccountResultDto;
            Assert.Equal(account.Balance, model.Balance);
            Assert.Equal(account.AccountNumber, model.AccountNumber);
            Assert.Equal(account.FirstName, model.FirstName);
            Assert.Equal(account.LastName, model.LastName);
        }

        [Fact]
        public void Transfer_ReturnsOk_WhenOperationIsSuccesful()
        {
            // Arrange
            var amount = 8979;
            var fromAccountBalance = 8888888;
            var fromAccountNumber = "FDOJIO";
            var toAccountNumber = "iofdsa";
            var transferAccountDto = new TransferAccountDto()
            {
                Amount = amount,
                FromAccountNumber = fromAccountNumber,
                ToAccountNumber = toAccountNumber
            };

            var transferResult = new TransferResult()
            {
                Amount = amount,
                FromAccountNumber= fromAccountNumber,
                ToAccountNumber= toAccountNumber,
                FromAccountNumberBalance= fromAccountBalance,
            };

            _mockAccountService.Setup(x => x.TransferAccount(It.IsAny<TransferAccount>()))
                .Returns(transferResult);

            // Act
            var actual = _controller.Transfer(transferAccountDto) as OkObjectResult;

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(StatusCodes.Status200OK, actual.StatusCode);

            var model = actual.Value as TransferAccountResultDto;
            Assert.Equal(transferResult.FromAccountNumberBalance, model.FromAccountNumberBalance);
            Assert.Equal(transferResult.FromAccountNumber, model.FromAccountNumber);
            Assert.Equal(transferResult.ToAccountNumber, model.ToAccountNumber);
            Assert.Equal(transferResult.Amount, model.Amount);
        }
    }
}