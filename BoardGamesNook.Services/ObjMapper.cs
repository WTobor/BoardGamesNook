using AutoMapper;
using BoardGamesNook.Services.MapperProfiles;

namespace BoardGamesNook.Services
{
    public static class ObjMapper
    {
        public static void AddServicesProfiles(this IMapperConfigurationExpression cfg)
        {
            cfg.AddProfile<BoardGameDtoProfile>();
            cfg.AddProfile<GameTableDtoProfile>();
            cfg.AddProfile<GameResultDtoProfile>();
        }
    }
}