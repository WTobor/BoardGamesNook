using System.Collections.Generic;
using BoardGamesNook.Model;

namespace BoardGamesNook.Repository.Interfaces
{
    public interface IGameTableRepository
    {
        GameTable Get(int id);

        IEnumerable<GameTable> GetAll();

        IEnumerable<BoardGame> GetAvailableTableBoardGameList(GameTable table);

        IEnumerable<GameTable> GetAllByGamerNick(string nick);

        void Add(GameTable gameTable);

        void EditParticipations(List<GameParticipation> gameParticipations, Gamer modifiedGamer);

        void Edit(GameTable gameTable);

        void Delete(int id);
    }
}