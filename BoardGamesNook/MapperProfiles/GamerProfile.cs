using AutoMapper;
using BoardGamesNook.Model;
using BoardGamesNook.ViewModels.Gamer;
using BoardGamesNook.ViewModels.GamerBoardGame;

namespace BoardGamesNook.MapperProfiles
{
    public class GamerProfile : Profile
        {
            public GamerProfile()
            {
                CreateMap<Gamer, GamerViewModel>();
                CreateMap<Gamer, GamerBoardGameViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.ImageUrl, opt => opt.Ignore())
                    .ForMember(dest => dest.GamerId, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.GamerNickname, opt => opt.MapFrom(src => src.Nickname));
            }
        }
    }