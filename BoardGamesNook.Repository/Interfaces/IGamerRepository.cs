using BoardGamesNook.Model;
using System.Collections.Generic;

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

        void Delete(string id);
    }
}