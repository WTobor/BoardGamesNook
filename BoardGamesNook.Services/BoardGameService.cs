using BoardGamesNook.Model;
using BoardGamesNook.Repository.Interfaces;
using BoardGamesNook.Services.Interfaces;
using System.Collections.Generic;

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
            return _boardGameRepository.Get(id);
        }

        public IEnumerable<BoardGame> GetAll()
        {
            return _boardGameRepository.GetAll();
        }

        public void Add(BoardGame boardGame)
        {
            _boardGameRepository.Add(boardGame);
        }

        public void Edit(BoardGame boardGame)
        {
            _boardGameRepository.Edit(boardGame);
        }

        public void Delete(int id)
        {
            _boardGameRepository.Delete(id);
        }
    }
}