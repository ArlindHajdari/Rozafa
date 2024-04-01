using ErrorOr;
using MediatR;
using Rozafa.Application.Common.Customer;
using Rozafa.Application.Common.Interfaces;
using Rozafa.Domain.Common.Errors;

namespace Rozafa.Application.Services.Customer.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<bool>>
{   
    private readonly ICustomer _customer;

    public RegisterCommandHandler(ICustomer customer)
    {
        _customer = customer;
    }
    public async Task<ErrorOr<bool>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if(request.User.LastName == string.Empty)
        {
            return Errors.Customer.EmptyLastName;
        }

        return _customer.RegisterCustomer(new Domain.Models.RegisterCustomer(request.User.FirstName, request.User.LastName));  
    }
}