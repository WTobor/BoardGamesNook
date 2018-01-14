using BoardGamesNook.Model;
using System.Collections.Generic;

namespace BoardGamesNook.Services.Interfaces
{
    public interface IGamerService
    {
        Gamer GetGamer(string id);

        Gamer GetGamerByEmail(string userEmail);

        Gamer GetGamerBoardGameByNickname(string userNickname);

        bool NicknameExists(string nickname);

        IEnumerable<Gamer> GetAllGamers();

        void AddGamer(Gamer gamer);

        void EditGamer(Gamer gamer);

        void DeactivateGamer(string id);
    }
}