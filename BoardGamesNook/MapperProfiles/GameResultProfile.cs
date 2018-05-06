using AutoMapper;
using BoardGamesNook.Model;
using BoardGamesNook.Services.Models;
using BoardGamesNook.ViewModels.GameResult;

namespace BoardGamesNook.MapperProfiles
{
    public class GameResultProfile : Profile
    {
        public GameResultProfile()
        {
            CreateMap<GameResultViewModel, GameResultDto>();
            CreateMap<GameResult, GameResultViewModel>();
            CreateMap<GameResultViewModel, GameResult>();
        }
    }
}