using AutoMapper;
using BoardGamesNook.Model;
using BoardGamesNook.ViewModels.Gamer;

namespace BoardGamesNook.Profiles
{
    public class GamerProfile : Profile
    {
        public GamerProfile()
        {
            CreateMap<Gamer, GamerViewModel>();
        }
    }
}