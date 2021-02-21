using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Profiles
{
    public class TodoProfiles : Profile
    {
        public TodoProfiles()
        {
            CreateMap<User, UserDto>()
            .ForMember(
                dest => dest.Age, 
                src => src.MapFrom(s => s.Dob.CalculateAge()))
            .ForMember(
                dest => dest.FullName,
                src => src.MapFrom(s => $"{s.FirstName} {s.LastName}"));

            CreateMap<UserForCreationDto, User>();
        }
    }
}