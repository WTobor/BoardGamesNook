﻿using AutoMapper;
using BoardGamesNook.Model;
using BoardGamesNook.Services.Models;

namespace BoardGamesNook.MapperProfiles
{
    public class BoardGameProfile : Profile
    {
        public BoardGameProfile()
        {
            CreateMap<BoardGame, TableBoardGameDto>()
                .ForMember(dest => dest.BGGId, opt => opt.MapFrom(src => src.BGGId))
                .ForMember(dest => dest.BoardGameId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.BoardGameName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.MinBoardGamePlayers, opt => opt.MapFrom(src => src.MinPlayers))
                .ForMember(dest => dest.MaxBoardGamePlayers, opt => opt.MapFrom(src => src.MaxPlayers))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));
        }
    }
}