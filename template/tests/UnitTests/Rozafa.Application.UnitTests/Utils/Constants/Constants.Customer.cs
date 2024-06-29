namespace Rozafa.Application.UnitTests.Utils.Constants;

public static partial class Constants
{
    public static class Customer
    {
        public const string FirstName = "John";
        public const string LastName = "Doe";

        public static User CreateUser(string identifier = null!) =>
            new User(
                $"{FirstName} {identifier?.ToString()}",
                LastName);
    }
}
