using Castle.Core.Logging;
using Domain;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace Banking.Service.Test
{
    public class AccountNumberGeneratorTests
    {
        private readonly AccountNumberGenerator _generator;

        private readonly Mock<IHttpClientFactory> _mockHttpClientFactory;
        private readonly Mock<ILogger<AccountNumberGenerator>> _mockLogger;
        private readonly Mock<IOptions<GeneratorSettings>> _mockSettings;

        public AccountNumberGeneratorTests()
        {
            _mockHttpClientFactory = new Mock<IHttpClientFactory>();
            _mockLogger = new Mock<ILogger<AccountNumberGenerator>>();
            _mockSettings = new Mock<IOptions<GeneratorSettings>>();

            _generator = new AccountNumberGenerator(_mockHttpClientFactory.Object,
                _mockLogger.Object,
                _mockSettings.Object);
        }

        [Fact]
        public async Task GenerateAccountNumberAsync_ReturnsAccountNumber_WhenOperationIsSuccessful()
        {
            // Arrange


            // Act
            var result = await _generator.GenerateAccountNumberAsync();

            // Assert
            Assert.NotNull(result);
        }
    }
}