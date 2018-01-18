using System.Collections.Generic;
using System.Diagnostics;
using AutoMapper;
using BoardGamesNook.Model;
using BoardGamesNook.ViewModels.GamerBoardGame;

namespace BoardGamesNook.Profiles
{
    public class GamerBoardGameProfile : Profile
    {
        public GamerBoardGameProfile()
        {
            CreateMap<GamerBoardGame, GamerBoardGameViewModel>();
            CreateMap<GamerBoardGameViewModel, GamerBoardGame>();
            CreateMap<BoardGame, GamerBoardGameViewModel>();
        }
    }
}