using Rozafa.Application.UnitTests.Utils.Constants;

namespace Rozafa.Application.UnitTests.Customer.Commands.Utils;

public static class RegisterCustomerCommandUtils
{
    public static RegisterCommand CreateCommand(string identifier = null!) =>
        new RegisterCommand(
            Constants.Customer.CreateUser(identifier)
        );
}
