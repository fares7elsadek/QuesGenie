using AutoMapper;
using QuesGenie.Application.Authentication.Commands.RegisterUser;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Application.Authentication.Dtos;

public class UserProfile:Profile
{
    public UserProfile()
    {
        CreateMap<ApplicationUser, RegisterUserCommand>()
            .ForMember(dest => dest.Password, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<ApplicationUser, UserDto>()
            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
            .ReverseMap();
    }
}