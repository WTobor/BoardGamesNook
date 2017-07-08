using BoardGamesNook.Model;
using System.Collections.Generic;

namespace BoardGamesNook.Services.Interfaces
{
    public interface IGamerService
    {
        Gamer Get(string id);

        Gamer GetByEmail(string userEmail);

        Gamer GetByNick(string userNick);

        bool NickExists(string nick);

        IEnumerable<Gamer> GetAll();

        void Add(Gamer gamer);

        void Edit(Gamer gamer);

        void Deactivate(string id);
    }
}