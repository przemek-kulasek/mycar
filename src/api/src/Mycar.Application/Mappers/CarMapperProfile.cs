using AutoMapper;
using Mycar.Application.Dtos;
using Mycar.Domain.Cars;

namespace Mycar.Application.Mappers
{
    public class CarMapperProfile : Profile
    {
        public CarMapperProfile()
        {
            CreateMap<CarDto, Car>();
            CreateMap<Car, CarDto>();

            CreateMap<Car, CarHistoryDto>()
                .ForMember(dest => dest.Car, opt => opt.MapFrom(source => source));
        }
    }
}
