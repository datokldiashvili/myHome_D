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
                .ForMember(dest => dest.PhotoUrl,
                           opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(dest => dest.Age,
                           opt => opt.MapFrom(src => CalculateAge(src.DateOfBirth)));

            CreateMap<Photo, PhotoDto>();
            CreateMap<RegisterDto, AppUser>();
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
