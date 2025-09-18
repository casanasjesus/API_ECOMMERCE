using AutoMapper;
using MSCustomer.API.Dtos;
using MSCustomer.Application.Dtos;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CreateCustomerRequest, CreateCustomerDto>();
        CreateMap<UpdateCustomerRequest, UpdateCustomerDto>();
    }
}
