using AutoMapper;
using BoardGamesNook.Model;
using BoardGamesNook.ViewModels.GamerBoardGame;
using BoardGamesNook.ViewModels.GameTable;

namespace BoardGamesNook.MapperProfiles
{
    public class BoardGameProfile : Profile
    {
        public BoardGameProfile()
        {
            CreateMap<BoardGame, GamerBoardGameViewModel>()
                .ForMember(dest => dest.BoardGameId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.BoardGameName, opt => opt.MapFrom(src => src.Name));
            CreateMap<BoardGame, TableBoardGameViewModel>()
                .ForMember(dest => dest.BGGId, opt => opt.MapFrom(src => src.BGGId))
                .ForMember(dest => dest.BoardGameId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.BoardGameName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));
        }
    }
}