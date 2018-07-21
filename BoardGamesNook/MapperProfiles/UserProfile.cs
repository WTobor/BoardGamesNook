using System;
using AutoMapper;
using BoardGamesNook.Model;
using SimpleAuthentication.Core;

namespace BoardGamesNook.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserInformation, User>()
                .ForMember(dest => dest.Id, opt => Guid.NewGuid().ToString())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Picture))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Confirmed, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.GenderType, opt => opt.MapFrom(src => (int) src.Gender));
        }
    }
}