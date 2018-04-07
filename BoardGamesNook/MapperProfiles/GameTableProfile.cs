using AutoMapper;
using BoardGamesNook.Services.Models;
using BoardGamesNook.ViewModels.GameTable;

namespace BoardGamesNook.MapperProfiles
{
    public class GameTableProfile : Profile
    {
        public GameTableProfile()
        {
            CreateMap<BoardGameDto, TableBoardGameViewModel>();
        }
    }
}