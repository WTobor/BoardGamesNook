using AutoMapper;
using BoardGamesNook.Model;
using BoardGamesNook.ViewModels.GameResult;

namespace BoardGamesNook.MapperProfiles
{
    public class GameResultProfile : Profile
    {
        public GameResultProfile()
        {
            CreateMap<GameResult, GameResultViewModel>()
                .ForMember(dest => dest.GamerId, opt => opt.MapFrom(src => src.Gamer.Id))
                .ForMember(dest => dest.GamerNickname, opt => opt.MapFrom(src => src.Gamer.Nickname));
        }
    }
}