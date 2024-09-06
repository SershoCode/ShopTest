using AutoMapper;
using Shop.Application.Contracts;
using Shop.Domain;

namespace Shop.Application;

public class ShopAppProfile : Profile
{
    public ShopAppProfile()
    {
        CreateMap<Person, PersonDto>();
        CreateMap<Product, ProductDto>();
    }
}
