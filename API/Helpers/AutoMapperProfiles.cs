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
                opt => opt.MapFrom(src =>
                    $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.Country, opt =>
                opt.MapFrom(src => src.ContactDetail.Country))
            .ForMember(dest => dest.City, opt =>
                opt.MapFrom(src => src.ContactDetail.City))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetail.PhoneNumber));
        
        CreateMap<RegisterDto, AppUser>();
        CreateMap<ContactDetail, ContactDetailDto>();
        CreateMap<ContactDetailDto, ContactDetail>();
        CreateMap<Institution, InstitutionDto>();
        CreateMap<InstitutionDto, Institution>();
        
        CreateMap<ClassSchedule, ClassScheduleDto>()
    .ForMember(dest => dest.DayOfWeek, opt => opt.MapFrom(src => src.DayOfWeek.ToString()))
    .ForMember(dest => dest.TimeOfDay, opt => opt.MapFrom(src => src.TimeOfDay.ToString()))
    .ForMember(dest => dest.ModuleName, opt => opt.MapFrom(src => src.Module.Name))
    .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Module.Course.Name));

    }
}