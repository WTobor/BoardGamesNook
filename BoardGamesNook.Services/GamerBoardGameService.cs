using System;
using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Interfaces;
using BoardGamesNook.Services.Interfaces;

namespace BoardGamesNook.Services
{
    public class GamerBoardGameService : IGamerBoardGameService
    {
        private readonly IBoardGameService _boardGameService;
        private readonly IGamerBoardGameRepository _gamerBoardGameRepository;

        public GamerBoardGameService(IGamerBoardGameRepository gamerBoardGameRepository,
            IBoardGameService boardGameService)
        {
            _gamerBoardGameRepository = gamerBoardGameRepository;
            _boardGameService = boardGameService;
        }

        public GamerBoardGame GetGamerBoardGame(int id)
        {
            return _gamerBoardGameRepository.Get(id);
        }

        public IEnumerable<BoardGame> GetGamerAvailableBoardGameList(string nickname)
        {
            var availableBoardGameList = _boardGameService.GetAll();
            var gamerBoardGameList = GetAllGamerBoardGamesByGamerNickname(nickname);
            var gamerAvailableBoardGameList = availableBoardGameList
                .Where(x => gamerBoardGameList.All(y => y.BoardGameId != x.Id)).ToList();
            return gamerAvailableBoardGameList;
        }

        public IEnumerable<GamerBoardGame> GetAllGamerBoardGames()
        {
            return _gamerBoardGameRepository.GetAll();
        }

        public IEnumerable<GamerBoardGame> GetAllGamerBoardGamesByGamerNickname(string gamerNickname)
        {
            return _gamerBoardGameRepository.GetAllByGamerNickname(gamerNickname);
        }

        public void DeactivateGamerBoardGame(int id)
        {
            _gamerBoardGameRepository.Deactivate(id);
        }

        public void Add(int boardGameId, Gamer gamer)
        {
            var gamerBoardGame = GetGamerBoardGameObj(boardGameId, gamer);
            _gamerBoardGameRepository.Add(gamerBoardGame);
        }

        public void EditGamerBoardGame(int gamerBoardGameId)
        {
            var gamerBoardGame = GetGamerBoardGame(gamerBoardGameId);
            _gamerBoardGameRepository.Edit(gamerBoardGame);
        }

        private GamerBoardGame GetGamerBoardGameObj(int boardGameId, Gamer gamer)
        {
            return new GamerBoardGame
            {
                Id = GetAllGamerBoardGames().Select(x => x.Id).LastOrDefault() + 1,
                GamerId = gamer.Id,
                Gamer = gamer,
                BoardGameId = boardGameId,
                BoardGame = _boardGameService.Get(boardGameId),
                CreatedDate = DateTimeOffset.Now,
                Active = true
            };
        }
    }
}