using AutoMapper;
using BoardGamesNook.Model;
using BoardGamesNook.ViewModels.GameTable;

namespace BoardGamesNook.MapperProfiles
{
    public class GameTableProfile : Profile
    {
        public GameTableProfile()
        {
            CreateMap<GameTable, GameTableViewModel>();
            CreateMap<GameTable, TableBoardGameViewModel>()
                .ForMember(dest => dest.GamerId, opt => opt.MapFrom(src => src.CreatedGamerId))
                .ForMember(dest => dest.GamerNickname, opt => opt.MapFrom(src => src.CreatedGamer.Nickname))
                .ForMember(dest => dest.TableId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TableName, opt => opt.MapFrom(src => src.Name));
        }
    }
}