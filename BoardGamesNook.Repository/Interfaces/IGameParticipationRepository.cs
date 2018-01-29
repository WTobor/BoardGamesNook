using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Interfaces
{
    public interface IGameParticipationRepository
    {
        GameParticipation GetGameParticipation(int id);

        IEnumerable<GameParticipation> GetAllGameParticipations();

        IEnumerable<GameParticipation> GetAllGameParticipationsByTableId(int id);

        void AddGameParticipation(GameParticipation gameParticipation);

        void EditGameParticipation(GameParticipation gameParticipation);

        void DeleteGameParticipation(int id);
    }
}