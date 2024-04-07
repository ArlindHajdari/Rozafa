// <copyright file="RozafaDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;

namespace Rozafa.Infrastructure.Persistence;

public class RozafaDbContext : DbContext
{
    public RozafaDbContext(DbContextOptions<RozafaDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> User { get; set; } = null!;

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.
            ApplyConfigurationsFromAssembly(typeof(RozafaDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}