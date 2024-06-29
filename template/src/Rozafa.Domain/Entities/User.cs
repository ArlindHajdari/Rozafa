// <copyright file="User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

public class User
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public User(string _firstName, string _lastName)
    {
        FirstName = _firstName;
        LastName = _lastName;
    }
}