using Domain;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Banking.Service
{
    public class AccountNumberGenerator : IAccountNumberGenerator
    {
        private readonly string CountryCode = "NL";

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<AccountNumberGenerator> _logger;
        private readonly GeneratorSettings _settings;

        public AccountNumberGenerator(IHttpClientFactory httpClientFactory,
            ILogger<AccountNumberGenerator> logger,
            IOptions<GeneratorSettings> settings)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _settings = settings.Value ?? throw new ArgumentNullException(nameof(settings));
        }

        public async Task<string> GenerateAccountNumberAsync()
        {
            using HttpClient client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("X-Api-Key", _settings.ApiKey);

            var accountNumber = "";
            try
            {
                accountNumber = await client.GetFromJsonAsync<string>(
                    _settings.Url + CountryCode,
                    new JsonSerializerOptions(JsonSerializerDefaults.Web));
            }
            catch (Exception ex)
            {
                _logger.LogError("Error getting something fun to say: {Error}", ex);
            }
            return accountNumber;
        }
    }
}
