// <copyright file="ApplicationConfiguration.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;

using Rozafa.Application.Common.Extensions;
using Rozafa.Application.Common.Interfaces;

namespace Rozafa.Application.Common
{
    public sealed class ApplicationConfiguration : IApplicationConfiguration
    {
        private readonly IConfiguration _config;

        public RICE RICE { get; private set; }

        public Auth Auth { get; private set; }

        public ApplicationConfiguration(IConfiguration config)
        {
            _config = config;
            Setup();
        }

        private void Setup()
        {
            RICE = new(
                _config.GetSection("RICE:BaseURL").GetSafe(),
                new(
                    _config.GetSection("RICE:Customer:GETCustomer").GetSafe(),
                    _config.GetSection("RICE:Customer:PUTCustomer").GetSafe()));

            Auth = new(
                _config.GetSection("Auth:URL").GetSafe(),
                _config.GetSection("Auth:tokenEndpoint").GetSafe());
        }
    }

    public sealed class RICE
    {
        public string BaseURL { get; set; }

        #region [Records]

        public record Customer(string GetCustomer, string UpdateCustomer);

        #endregion

        public Customer CustomerData { get; set; }

        public RICE(string _baseURL, Customer _customerData)
        {
            CustomerData = _customerData;
            BaseURL = _baseURL;
        }
    }

    public record Auth(string baseUrl, string tokenEndpoint);
}