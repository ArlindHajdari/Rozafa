using FluentAssertions;

using Moq;

using Rozafa.Application.Common.Interfaces;
using Rozafa.Application.Services.Customer.Commands.Register;
using Rozafa.Application.UnitTests.Customer.Commands.Utils;
using Rozafa.Application.UnitTests.Utils.Customer.Extensions;

namespace Rozafa.Application.UnitTests.Customer.Commands.Register;

public class RegisterCustomerCommandHandlerTests
{
    private readonly RegisterCommandHandler _registerCommandHandler;
    private readonly Mock<ICustomer> _mockCustomer;

    public RegisterCustomerCommandHandlerTests()
    {
        _mockCustomer = new Mock<ICustomer>();
        _registerCommandHandler = new RegisterCommandHandler(_mockCustomer.Object);
    }

    [Theory]
    [MemberData(nameof(ValidRegisterCustomerCommands))]
    public async Task HandleRegisterCustomerCommand_WhenCustomerIsValid_ShouldRegisterCustomer(RegisterCommand registerCustomerCommand)
    {
        ErrorOr.ErrorOr<string> result = await _registerCommandHandler.Handle(registerCustomerCommand, default);

        result.IsError.Should().BeFalse();
        result.Value.ValidateRegisterFrom(registerCustomerCommand);
        //Act
        //Assert 
    }

    public static IEnumerable<object[]> ValidRegisterCustomerCommands()
    {
        yield return new[] { RegisterCustomerCommandUtils.CreateCommand() };

        yield return new[] { RegisterCustomerCommandUtils.CreateCommand("_ID") };
    }
}
