using AutoMapper;
using BulbEd.DTOs;
using BulbEd.Entities;

namespace BulbEd.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<AppUser, MemberDto>()
            .ForMember(dest => dest.PhotoUrl, 
                opt => opt.MapFrom(src => src.Photo.Url))
            .ForMember(dest => dest.FullName, 
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => src.Status.ToString()))
            .ForMember(dest => dest.Roles, opt =>
                opt.MapFrom(src => src.UserRoles.Select(ur => ur.Role.Name).ToList()));
    }
    
}