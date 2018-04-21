using AutoMapper;
using BoardGamesNook.Model;
using BoardGamesNook.Services.Models;

namespace BoardGamesNook.Services.MapperProfiles
{
    internal class GameResultDtoProfile : Profile
    {
        public GameResultDtoProfile()
        {
            CreateMap<GameResult, GameResultDto>()
                .ForMember(dest => dest.GamerId, opt => opt.MapFrom(src => src.Gamer.Id))
                .ForMember(dest => dest.GamerNickname, opt => opt.MapFrom(src => src.Gamer.Nickname));

            CreateMap<Gamer, GameResultDto>()
                .ForMember(dest => dest.GamerId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.GamerNickname, opt => opt.MapFrom(src => src.Nickname));
        }
    }
}