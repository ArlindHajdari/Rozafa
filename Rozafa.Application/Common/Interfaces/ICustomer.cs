using Rozafa.Domain.Models;

namespace Rozafa.Application.Common.Interfaces;

public interface ICustomer
{
    Guid GetCustomerID();
    bool RegisterCustomer(RegisterCustomer customer);
}