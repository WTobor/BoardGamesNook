using System;
using AutoMapper;
using BoardGamesNook.Model;
using BoardGamesNook.Services.Models;

namespace BoardGamesNook.Services.MapperProfiles
{
    public class GameTableDtoProfile : Profile
    {
        public GameTableDtoProfile()
        {
            CreateMap<GameTable, GameTableDto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TableBoardGameList, opt => opt.Ignore());

            CreateMap<GameTable, TableBoardGameDto>()
                .ForMember(dest => dest.GamerId, opt => opt.MapFrom(src => src.CreatedGamerId))
                .ForMember(dest => dest.TableId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TableName, opt => opt.MapFrom(src => src.Name));


            CreateMap<GameTableDto, GameTable>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.IsFull, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
                .ForMember(dest => dest.IsPrivate, opt => opt.MapFrom(src => src.IsPrivate))
                .ForMember(dest => dest.MinPlayersNumber, opt => opt.MapFrom(src => src.MinPlayers))
                .ForMember(dest => dest.MaxPlayersNumber, opt => opt.MapFrom(src => src.MaxPlayers))
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(src => DateTimeOffset.Now));
        }
    }
}