using BoardGamesNook.Model;
using System.Collections.Generic;

namespace BoardGamesNook.Services.Interfaces
{
    public interface IGameParticipationService
    {
        GameParticipation Get(int id);

        IEnumerable<GameParticipation> GetAll();

        IEnumerable<GameParticipation> GetAllByTableId(int id);

        void Add(GameParticipation gameParticipation);

        void Edit(GameParticipation gameParticipation);

        void Delete(int id);
    }
}
