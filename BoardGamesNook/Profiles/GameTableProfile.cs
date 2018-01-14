﻿using AutoMapper;
using BoardGamesNook.Model;
using BoardGamesNook.ViewModels.GameTable;

namespace BoardGamesNook.Mappers
{
    public class GameTableProfile : Profile
    {
        public GameTableProfile()
        {
            CreateMap<GameTable, GameTableViewModel>();
            //double
            CreateMap<BoardGame, TableBoardGameViewModel>();
            CreateMap<GameTable, TableBoardGameViewModel>();
        }
    }
}