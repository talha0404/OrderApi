using AutoMapper;
using OrderApi.Application.DTOs;
using OrderApi.Domain.Entities;

namespace OrderApi.Application.Mapping;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        //NOTE: ReverseMap() allows bidirectional mapping Entity->DTO, DTO->Entity
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
    }
}