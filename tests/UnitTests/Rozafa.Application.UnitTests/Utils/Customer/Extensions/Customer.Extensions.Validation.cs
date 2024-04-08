using FluentAssertions;

namespace Rozafa.Application.UnitTests.Utils.Customer.Extensions;

public static partial class CustomerExtensions
{
    public static void ValidateRegisterFrom(this string response, RegisterCommand command)
    {
        response.Should().Be(command.User.FirstName);//must work with response from HttpCall
    }
}
