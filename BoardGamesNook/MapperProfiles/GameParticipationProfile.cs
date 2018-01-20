using AutoMapper;
using BoardGamesNook.Model;
using BoardGamesNook.ViewModels.GameParticipation;

namespace BoardGamesNook.MapperProfiles
{
    public class GameParticipationProfile : Profile
    {
        public GameParticipationProfile()
        {
            CreateMap<GameParticipation, GameParticipationViewModel>();
            CreateMap<GameParticipationViewModel, GameParticipation>();
        }
    }
}