using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Interfaces
{
    public interface IGamerRepository
    {
        Gamer GetGamer(string id);

        Gamer GetGamerByEmail(string userEmail);

        Gamer GetGamerByNick(string userEmail);

        bool NickExists(string nick);

        IEnumerable<Gamer> GetAllGamers();

        void AddGamer(Gamer gamer);

        void EditGamer(Gamer gamer);

        void DeactivateGamer(string id);
    }
}