using AutoMapper;
using Mycar.Application.Dtos;
using Mycar.Domain.Maintenance;

namespace Mycar.Application.Mappers;

public class ItemMapperProfile : Profile
{
    public ItemMapperProfile()
    {
        CreateMap<ItemDto, Item>();
        CreateMap<Item, ItemDto>();
    }
}