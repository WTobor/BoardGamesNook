using AutoMapper;
using BoardGamesNook.Services.MapperProfiles;

namespace BoardGamesNook.Services
{
    internal class ObjMapper
    {
        public static void AddProfiles(IMapperConfigurationExpression cfg)
        {
            cfg.AddProfile<BoardGameObjProfile>();
            cfg.AddProfile<GameTableObjProfile>();
        }
    }
}