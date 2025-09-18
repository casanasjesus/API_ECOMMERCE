using AutoMapper;
using MSProduct.API.Dtos;
using MSProduct.Application.Dtos;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductRequest, CreateProductDto>();
        CreateMap<UpdateProductRequest, UpdateProductDto>();
    }
}
