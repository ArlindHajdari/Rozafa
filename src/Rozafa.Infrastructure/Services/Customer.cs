// <copyright file="Customer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Net;
using System.Text;

using Rozafa.Application.Common.Interfaces;
using Rozafa.Domain.Models.Customer;

namespace Rozafa.Infrastructure.Services;

public class Customer : ICustomer
{
    private readonly HttpClient _httpClient;
    private readonly IApplicationConfiguration _config;

#pragma warning disable SA1600 // Elements should be documented
    public Customer(
#pragma warning restore SA1600 // Elements should be documented
        IApplicationConfiguration config,
        IHttpClientFactory _httpClientFactory)
    {
#pragma warning disable SA1101 // Prefix local calls with this
        _config = config;
        _httpClient = _httpClientFactory.CreateClient(nameof(config.RICE));
#pragma warning restore SA1101 // Prefix local calls with this
    }

    /// <inheritdoc/>
    public Guid GetCustomerID()
    {
        return Guid.NewGuid();
    }

    /// <inheritdoc/>
    public async Task<string> RegisterCustomer(RegisterCustomer customer)
    {
        try
        {
            var request = new StringContent(customer.ToString(), Encoding.UTF8, "application/json");

            var result = await _httpClient.PostAsync(_config.RICE.CustomerData.GetCustomer, request);
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadAsStringAsync();
            return response;
        }
        catch(HttpRequestException ex)
        {
            throw ex;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}