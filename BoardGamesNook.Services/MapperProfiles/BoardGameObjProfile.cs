using AutoMapper;
using BoardGamesNook.Model;
using BoardGamesNook.Services.Objects;

namespace BoardGamesNook.Services.MapperProfiles
{
    public class BoardGameObjProfile : Profile
    {
        public BoardGameObjProfile()
        {
            //CreateMap<BoardGame, GamerBoardGameObj>()
            //    .ForMember(dest => dest.BoardGameId, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.BoardGameName, opt => opt.MapFrom(src => src.Name));
            CreateMap<BoardGame, TableBoardGameObj>()
                .ForMember(dest => dest.BGGId, opt => opt.MapFrom(src => src.BGGId))
                .ForMember(dest => dest.BoardGameId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.BoardGameName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.MinBoardGamePlayers, opt => opt.MapFrom(src => src.MinPlayers))
                .ForMember(dest => dest.MaxBoardGamePlayers, opt => opt.MapFrom(src => src.MaxPlayers))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));
            //CreateMap<BoardGameObj, BoardGame>();
        }
    }
}