using System;
using AutoMapper;
using BoardGamesNook.Model;
using BoardGamesNook.ViewModels.GameTable;

namespace BoardGamesNook.MapperProfiles
{
    public class GameTableProfile : Profile
    {
        public GameTableProfile()
        {
            //CreateMap<GameTable, GameTableViewModel>()
            //    .ForMember(dest => dest.Id, opt => opt.Ignore())
            //    .ForMember(dest => dest.TableBoardGameList, opt => opt.Ignore());

            //CreateMap<GameTable, TableBoardGameViewModel>()
            //    .ForMember(dest => dest.GamerId, opt => opt.MapFrom(src => src.CreatedGamerId))
            //    .ForMember(dest => dest.TableId, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.TableName, opt => opt.MapFrom(src => src.Name));


            //CreateMap<GameTableViewModel, GameTable>()
            //    .ForMember(dest => dest.Id, opt => opt.Ignore())
            //    .ForMember(dest => dest.IsFull, opt => opt.Ignore())
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            //    .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            //    .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
            //    .ForMember(dest => dest.IsPrivate, opt => opt.MapFrom(src => src.IsPrivate))
            //    .ForMember(dest => dest.MinPlayersNumber, opt => opt.MapFrom(src => src.MinPlayers))
            //    .ForMember(dest => dest.MaxPlayersNumber, opt => opt.MapFrom(src => src.MaxPlayers))
            //    .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(src => DateTimeOffset.Now));
        }
    }
}