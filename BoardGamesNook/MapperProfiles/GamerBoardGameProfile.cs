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
            CreateMap<GamerBoardGame, GamerBoardGameViewModel>();
        }
    }
}