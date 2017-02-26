using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Services.Interfaces
{
    public interface IGamerService
    {
        Gamer Get(int id);

        IEnumerable<Gamer> GetAll();

        void Add(Gamer gamer);

        void Edit(Gamer gamer);

        void Delete(int id);
    }
}