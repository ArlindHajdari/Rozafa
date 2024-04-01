using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rozafa.Contracts.Customer.Requests;

namespace Rozafa.API.Controllers;

[Route("Customer")]
[Authorize]
public class CustomerController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediatR;

    public CustomerController(IMapper mapper, ISender mediatR)
    {
        _mapper = mapper;
        _mediatR = mediatR;
    }

    [HttpPost("customer")]
    public async Task<IActionResult> RegisterCustomer(CustomerRegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        var result = await _mediatR.Send(command);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors));
    }
}