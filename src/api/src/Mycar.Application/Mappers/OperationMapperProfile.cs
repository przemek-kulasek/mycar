using AutoMapper;
using Mycar.Application.Dtos;
using Mycar.Domain.Maintenance;

namespace Mycar.Application.Mappers;

public class OperationMapperProfile : Profile
{
    public OperationMapperProfile()
    {
        CreateMap<OperationDto, Operation>();
        CreateMap<Operation, OperationDto>();

        CreateMap<Operation, OperationWithItemsDto>();
    }
}