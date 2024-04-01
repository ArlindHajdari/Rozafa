using ErrorOr;
using MediatR;
using Rozafa.Application.Common.Customer;

public record RegisterCommand(User User) : IRequest<ErrorOr<bool>>; 