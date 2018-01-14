using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Interfaces
{
    public interface IGamerRepository
    {
        Gamer GetGamer(string id);

        Gamer GetGamerByEmail(string userEmail);

        Gamer GetGamerByNickname(string userNickname);

        bool NicknameExists(string nickname);

        IEnumerable<Gamer> GetAllGamers();

        void AddGamer(Gamer gamer);

        void EditGamer(Gamer gamer);

        void DeactivateGamer(string id);
    }
}