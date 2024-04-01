using ErrorOr;

namespace Rozafa.Domain.Common.Errors;

public static class Errors
{
    public static class Customer
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "Customer.DuplicateEmail", 
            description: "Email is already in use!");

        public static Error EmptyLastName => Error.Validation(
            code: "96526", 
            description: "Last name can NOT be empty");
    }
}