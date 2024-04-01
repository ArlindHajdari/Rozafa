using ErrorOr;
using FluentValidation;
using MediatR;

namespace Rozafa.Application.Common.Behaviours;

public class ValidateBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
                                                    where TRequest : IRequest<TResponse> 
                                                    where TResponse : IErrorOr
{
    private readonly IValidator<TRequest> _validator;

    public ValidateBehaviour(IValidator<TRequest>? validator)
    {
        _validator = validator;
    }
    public async Task<TResponse> Handle(TRequest request, 
                                        RequestHandlerDelegate<TResponse> next, 
                                        CancellationToken cancellationToken)
    {
        if(_validator is null)
        {
            return await next();
        }

        var validation = await _validator.ValidateAsync(request);

        if (validation.IsValid)
        {
            return await next();
        }

        var errors = validation.Errors.ConvertAll(x => Error.Validation
                            (
                                x.PropertyName,
                                x.ErrorMessage
                            ));
        return (dynamic)errors;
    }
}