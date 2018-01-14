using AutoMapper;
using BoardGamesNook.Model;
using BoardGamesNook.ViewModels.GamerBoardGame;

namespace BoardGamesNook.Mappers
{
    public class GamerBoardGameProfile : Profile
    {
        public GamerBoardGameProfile()
        {
            CreateMap<GamerBoardGame, GamerBoardGameViewModel>();
            CreateMap<GamerBoardGameViewModel, GamerBoardGame>();
        }
    }
}