using AutoMapper;
using BoardGamesNook.Model;
using BoardGamesNook.ViewModels.GameResult;

namespace BoardGamesNook.Profiles
{
    public class GameResultProfile : Profile
    {
        public GameResultProfile()
        {
            CreateMap<GameResult, GameResultViewModel>()
                .ForMember(x => x.CreatedGamerId, map => map.MapFrom(y => y.Gamer.Id))
                .ForMember(x => x.CreatedGamerNickname, map => map.MapFrom(y => y.Gamer.Nickname));
        }
    }
}