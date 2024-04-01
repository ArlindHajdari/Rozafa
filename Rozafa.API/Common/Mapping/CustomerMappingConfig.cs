using Mapster;
using Rozafa.Contracts.Customer.Requests;

namespace Rozafa.API.Mapping;

public class CustomerMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CustomerRegisterRequest, RegisterCommand>()
            .Map(dest => dest.User, src => src);
    }
}