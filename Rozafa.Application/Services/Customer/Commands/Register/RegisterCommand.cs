// <copyright file="RegisterCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ErrorOr;
using MediatR;
using Rozafa.Application.Common.Customer;

public record RegisterCommand(User User) : IRequest<ErrorOr<string>>;