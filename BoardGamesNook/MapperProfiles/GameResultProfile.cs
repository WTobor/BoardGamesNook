using AutoMapper;
using BoardGamesNook.Services.Models;
using BoardGamesNook.ViewModels.GameResult;

namespace BoardGamesNook.MapperProfiles
{
    public class GameResultProfile : Profile
    {
        public GameResultProfile()
        {
            CreateMap<GameResultViewModel, GameResultDto>();
        }
    }
}