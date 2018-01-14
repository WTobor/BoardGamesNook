using BoardGamesNook.Model;
using System.Collections.Generic;

namespace BoardGamesNook.Services.Interfaces
{
    public interface IGamerService
    {
        Gamer Get(string id);

        Gamer GetGamerByEmail(string userEmail);

        Gamer GetByNick(string userNick);

        bool NickExists(string nick);

        IEnumerable<Gamer> GetAllGamers();

        void AddGamer(Gamer gamer);

        void EditGamer(Gamer gamer);

        void DeactivateGamer(string id);
    }
}