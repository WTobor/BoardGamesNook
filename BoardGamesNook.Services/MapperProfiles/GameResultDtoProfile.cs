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

            CreateMap<GameResultDto, GameResult>()
                .ForPath(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForPath(dest => dest.Gamer.Id, opt => opt.MapFrom(src => src.GamerId))
                .ForPath(dest => dest.Gamer.Nickname, opt => opt.MapFrom(src => src.GamerNickname));

            CreateMap<Gamer, GameResultDto>()
                .ForMember(dest => dest.GamerId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.GamerNickname, opt => opt.MapFrom(src => src.Nickname));

            CreateMap<Gamer, GameResult>()
                .ForMember(dest => dest.GamerId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Gamer, opt => opt.MapFrom(src => src));
        }
    }
}