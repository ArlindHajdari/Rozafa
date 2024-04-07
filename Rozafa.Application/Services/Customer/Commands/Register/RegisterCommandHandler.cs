// <copyright file="RegisterCommandHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ErrorOr;
using MediatR;
using Rozafa.Application.Common.Customer;
using Rozafa.Application.Common.Interfaces;
using Rozafa.Domain.Common.Errors;

namespace Rozafa.Application.Services.Customer.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<string>>
{
    private readonly ICustomer _customer;

    public RegisterCommandHandler(ICustomer customer)
    {
        _customer = customer;
    }

    public async Task<ErrorOr<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (request.User.LastName == string.Empty)
        {
            return Errors.Customer.EmptyLastName;
        }

        return await _customer.RegisterCustomer(new Domain.Models.RegisterCustomer(request.User.FirstName, request.User.LastName));
    }
}