using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Interfaces;
using BoardGamesNook.Services.Interfaces;

namespace BoardGamesNook.Services
{
    public class BoardGameService : IBoardGameService
    {
        private readonly IBoardGameRepository _boardGameRepository;

        public BoardGameService(IBoardGameRepository boardGameRepository)
        {
            _boardGameRepository = boardGameRepository;
        }

        public BoardGame Get(int id)
        {
            return _boardGameRepository.GetGamerBoardGame(id);
        }

        public IEnumerable<BoardGame> GetAllGamerBoardGames()
        {
            return _boardGameRepository.GetAllGamerBoardGames();
        }

        public void Add(BoardGame boardGame)
        {
            boardGame.Id = GetAllGamerBoardGames().Select(x => x.Id).LastOrDefault() + 1;
            _boardGameRepository.Add(boardGame);
        }

        public void Edit(BoardGame boardGame)
        {
            _boardGameRepository.EditGamerBoardGame(boardGame);
        }

        public void Delete(int id)
        {
            _boardGameRepository.DeleteGamerBoardGame(id);
        }
    }
}