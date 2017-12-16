using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Interfaces
{
    public interface IGamerRepository
    {
        Gamer Get(string id);

        Gamer GetByEmail(string userEmail);

        Gamer GetByNick(string userEmail);

        bool NickExists(string nick);

        IEnumerable<Gamer> GetAll();

        void Add(Gamer gamer);

        void Edit(Gamer gamer);

        void Deactivate(string id);
    }
}