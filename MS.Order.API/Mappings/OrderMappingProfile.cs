using AutoMapper;
using MSOrder.API.Dtos;
using MSOrder.Application.Dtos;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<CreateOrderRequest, CreateOrderDto>();
    }
}
