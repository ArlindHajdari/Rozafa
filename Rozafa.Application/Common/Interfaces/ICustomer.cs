// <copyright file="ICustomer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Rozafa.Domain.Models;

namespace Rozafa.Application.Common.Interfaces;

public interface ICustomer
{
    Guid GetCustomerID();

    Task<string> RegisterCustomer(RegisterCustomer customer);
}