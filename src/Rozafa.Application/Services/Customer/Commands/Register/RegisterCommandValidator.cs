// <copyright file="RegisterCommandValidator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using FluentValidation;

namespace Rozafa.Application.Services.Customer.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.User.FirstName).NotEmpty();
        RuleFor(x => x.User.LastName).NotEmpty();
    }
}