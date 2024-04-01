using Rozafa.Application.Common.Interfaces;
using Rozafa.Domain.Models;

namespace Rozafa.Infrastructure.Services;

public class Customer : ICustomer
{
    public Guid GetCustomerID()
    {
        return Guid.NewGuid();
    }

    public bool RegisterCustomer(RegisterCustomer customer)
    {
        return customer.FirstName != string.Empty;
    }
}