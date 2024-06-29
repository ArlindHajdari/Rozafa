// <copyright file="CustomerRegisterRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Rozafa.Contracts.Customer.Requests;
public record CustomerRegisterRequest(string FirstName, string LastName, string TraceId);