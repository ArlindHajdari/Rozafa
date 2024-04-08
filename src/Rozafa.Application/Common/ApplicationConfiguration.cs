/// <summary>
/// Represents the application configuration.
/// </summary>
/// <remarks>
/// This class is responsible for managing the application configuration settings.
/// It provides access to the RICE and Auth configurations.
/// </remarks>
/// <seealso cref="IApplicationConfiguration"/>
/// <example>
/// This example demonstrates how to use the ApplicationConfiguration class:
/// <code>
/// var config = new ApplicationConfiguration(configuration);
/// var riceBaseUrl = config.RICE.BaseURL;
/// var authBaseUrl = config.Auth.BaseURL;
/// </code>
/// </example>
/// <seealso cref="RICE"/>
/// <seealso cref="Auth"/>
using Microsoft.Extensions.Configuration;

using Rozafa.Application.Common.Extensions;
using Rozafa.Application.Common.Interfaces;

namespace Rozafa.Application.Common
{
    public sealed class ApplicationConfiguration : IApplicationConfiguration
    {
        private readonly IConfiguration _config;

        private const int DEFAULT_TIMEOUT = 30;
        public RICE RICE { get; }

        public Auth Auth { get; }

        public ApplicationConfiguration(IConfiguration config)
        {
            _config = config;
            RICE = new(
                _config.GetSection("RICE:BaseURL").GetSafe(),
                int.TryParse(_config.GetSection("RICE:Timeout").GetSafe(), out int RT) ? RT : DEFAULT_TIMEOUT,
                new(
                    _config.GetSection("RICE:Customer:GETCustomer").GetSafe(),
                    _config.GetSection("RICE:Customer:PUTCustomer").GetSafe()));

            Auth = new(
                _config.GetSection("Auth:URL").GetSafe(),
                _config.GetSection("Auth:tokenEndpoint").GetSafe(),
                int.TryParse(_config.GetSection("Auth:Timeout").GetSafe(), out int AT) ? AT : DEFAULT_TIMEOUT);
        }
    }

    public sealed class RICE
    {
        public string BaseURL { get; set; }
        public int Timeout { get; set; }

        #region [Records]

        public record Customer(
            string GetCustomer,
            string UpdateCustomer);

        #endregion

        public Customer CustomerData { get; set; }

        public RICE(string _baseURL, int _Timeout, Customer _customerData)
        {
            CustomerData = _customerData;
            BaseURL = _baseURL;
            Timeout = _Timeout;
        }
    }

    public record Auth(string baseUrl, string tokenEndpoint, int timeout);
}