using AutoMapper;
using BoardGamesNook.Model;
using BoardGamesNook.ViewModels.GamerBoardGame;

namespace BoardGamesNook.MapperProfiles
{
    public class GamerBoardGameProfile : Profile
    {
        public GamerBoardGameProfile()
        {
            CreateMap<GamerBoardGameViewModel, GamerBoardGame>();
            CreateMap<GamerBoardGame, GamerBoardGameViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.GamerId, opt => opt.MapFrom(src => src.GamerId))
                .ForMember(dest => dest.GamerNickname, opt => opt.MapFrom(src => src.Gamer.Nickname))
                .ForMember(dest => dest.BoardGameId, opt => opt.MapFrom(src => src.BoardGame.Id))
                .ForMember(dest => dest.BoardGameName, opt => opt.MapFrom(src => src.BoardGame.Name))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.BoardGame.ImageUrl))
                .ForMember(dest => dest.BGGId, opt => opt.MapFrom(src => src.BoardGame.BGGId));
            CreateMap<BoardGame, GamerBoardGameViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))  //temporary solution
                .ForMember(dest => dest.BoardGameId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.BoardGameName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));
        }
    }
}