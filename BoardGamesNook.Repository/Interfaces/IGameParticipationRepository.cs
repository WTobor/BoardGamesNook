using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Interfaces
{
    public interface IGameParticipationRepository
    {
        GameParticipation Get(int id);

        IEnumerable<GameParticipation> GetAll();

        IEnumerable<GameParticipation> GetAllByTableId(int id);

        void Add(GameParticipation gameParticipation);

        void Edit(GameParticipation gameParticipation);

        void Delete(int id);
    }
}
