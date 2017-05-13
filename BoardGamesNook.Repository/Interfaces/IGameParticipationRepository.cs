using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNookNook.Repository.Interfaces
{
    public interface IGameParticipationRepository
    {
        GameParticipation Get(int id);

        IEnumerable<GameParticipation> GetAll();

        void Add(GameParticipation gameParticipation);

        void Edit(GameParticipation gameParticipation);

        void Delete(int id);
    }
}
