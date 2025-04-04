using AutoMapper;
using CarStoreApp.Server.DTOs;
using CarStoreApp.Server.Entities;

namespace CarStoreApp.Server.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Car, CarDto>();
        CreateMap<CarPhoto, CarPhotoDto>();
        CreateMap<CreateCarDto, Car>();
        CreateMap<CreateCarPhotoDto, CarPhoto>();
      

        CreateMap<User, UserDto>();
        CreateMap<User, RegisterDTO>();
        CreateMap<RegisterDTO, User>();
        //  .ForMember(dest => dest.Password, opt => opt.Ignore());
    }
}

