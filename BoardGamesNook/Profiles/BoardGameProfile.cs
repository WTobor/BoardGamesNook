using AutoMapper;
using BoardGamesNook.Model;
using BoardGamesNook.ViewModels.GamerBoardGame;

namespace BoardGamesNook.Mappers
{
    public class BoardGameProfile : Profile
    {
        public BoardGameProfile()
        {
            //double
            CreateMap<BoardGame, GamerBoardGameViewModel>().ForMember(x => x.BoardGameId, map => map.MapFrom(y => y.Id))
                .ForMember(x => x.BoardGameName, map => map.MapFrom(y => y.Name));
            CreateMap<Gamer, GamerBoardGameViewModel>().ForMember(x => x.GamerId, map => map.MapFrom(y => y.Id))
                .ForMember(x => x.GamerNickname, map => map.MapFrom(y => y.Nickname));
        }
    }
}