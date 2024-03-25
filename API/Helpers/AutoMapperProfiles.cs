using API.DTOs;
using API.Entities;
using AutoMapper;
using System;
using System.Linq;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src =>
                    src.Photos.FirstOrDefault(x => x.IsMain) != null ?
                    src.Photos.FirstOrDefault(x => x.IsMain).Url : null))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src =>
                    CalculateAge(src.DateOfBirth)))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src =>
                    src.Gender != null ? src.Gender.Name : null))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src =>
                    src.City != null ? src.City.Name : null))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src =>
                    src.Country != null ? src.Country.Name : null));
        }

        private int CalculateAge(DateTime dateOfBirth)
        {
            int age = DateTime.UtcNow.Year - dateOfBirth.Year;

            if (dateOfBirth.Date > DateTime.UtcNow.AddYears(-age))
                age--;

            return age;
        }
    }
}
