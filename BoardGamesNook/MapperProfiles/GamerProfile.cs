using System;
using AutoMapper;
using BoardGamesNook.Model;
using BoardGamesNook.ViewModels.Gamer;
using BoardGamesNook.ViewModels.GamerBoardGame;
using BoardGamesNook.ViewModels.GameResult;
using BoardGamesNook.ViewModels.GameTable;

namespace BoardGamesNook.MapperProfiles
{
    public class GamerProfile : Profile
    {
        public GamerProfile()
        {
            CreateMap<Gamer, GamerBoardGameViewModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ImageUrl, opt => opt.Ignore())
                .ForMember(dest => dest.GamerId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.GamerNickname, opt => opt.MapFrom(src => src.Nickname));

            CreateMap<Gamer, TableBoardGameViewModel>()
                .ForMember(dest => dest.BGGId, opt => opt.Ignore())
                .ForMember(dest => dest.BoardGameId, opt => opt.Ignore())
                .ForMember(dest => dest.BoardGameName, opt => opt.Ignore())
                .ForMember(dest => dest.TableId, opt => opt.Ignore())
                .ForMember(dest => dest.TableName, opt => opt.Ignore())
                .ForMember(dest => dest.ImageUrl, opt => opt.Ignore())
                .ForMember(dest => dest.GamerId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.GamerNickname, opt => opt.MapFrom(src => src.Nickname));

            CreateMap<Gamer, GameResultViewModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedGamerId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CreatedGamerId, opt => opt.MapFrom(src => src.Nickname));

            CreateMap<GamerViewModel, Gamer>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Email, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.Nickname, opt => opt.MapFrom(src => src.Nickname))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(src => DateTimeOffset.Now))
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => true));
        }
    }
}