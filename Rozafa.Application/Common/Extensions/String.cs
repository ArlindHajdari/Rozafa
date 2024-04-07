// <copyright file="String.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

namespace Rozafa.Application.Common.Extensions
{
    public static class String
    {
        public static string GetSafe(this IConfigurationSection value) => value is null ? string.Empty : value.Value.ToString();
    }
}