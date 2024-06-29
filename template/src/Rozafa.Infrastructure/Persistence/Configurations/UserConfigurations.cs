// <copyright file="UserConfigurations.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Rozafa.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfiguratUserTable(builder);
    }

    private void ConfiguratUserTable(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.HasNoKey();
    }
}