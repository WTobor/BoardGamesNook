using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Services.Interfaces
{
    public interface IGameParticipationService
    {
        GameParticipation GetGameParticipation(int id);

        IEnumerable<GameParticipation> GetAllGameParticipations();

        IEnumerable<GameParticipation> GetAllGameParticipationsByTableId(int id);

        void AddGameParticipation(GameParticipation gameParticipation);

        void Edit(GameParticipation gameParticipation);

        void Delete(int id);
    }
}