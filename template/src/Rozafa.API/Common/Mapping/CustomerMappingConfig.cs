// <copyright file="CustomerMappingConfig.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Mapster;
using Rozafa.Contracts.Customer.Requests;

namespace Rozafa.API.Mapping;

public class CustomerMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CustomerRegisterRequest, RegisterCommand>()
            .Map(dest => dest.User, src => src);
    }
}