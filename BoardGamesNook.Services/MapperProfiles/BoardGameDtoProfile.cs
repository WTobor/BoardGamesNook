using AutoMapper;
using BoardGamesNook.Model;
using BoardGamesNook.Services.Models;

namespace BoardGamesNook.Services.MapperProfiles
{
    public class BoardGameDtoProfile : Profile
    {
        public BoardGameDtoProfile()
        {
            CreateMap<Gamer, TableBoardGameDto>()
                .ForMember(dest => dest.GamerId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.GamerNickname, opt => opt.MapFrom(src => src.Nickname));
            CreateMap<BoardGame, TableBoardGameDto>()
                .ForMember(dest => dest.BGGId, opt => opt.MapFrom(src => src.BGGId))
                .ForMember(dest => dest.BoardGameId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.BoardGameName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.MinBoardGamePlayers, opt => opt.MapFrom(src => src.MinPlayers))
                .ForMember(dest => dest.MaxBoardGamePlayers, opt => opt.MapFrom(src => src.MaxPlayers))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));
            CreateMap<BoardGame, BoardGameDto>();
        }
    }
}