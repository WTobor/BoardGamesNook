using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BoardGamesNook.Model;
using BoardGamesNook.Repository.Interfaces;
using BoardGamesNook.Services.Interfaces;
using BoardGamesNook.Services.Models;

namespace BoardGamesNook.Services
{
    public class GameResultService : IGameResultService
    {
        private readonly IBoardGameRepository _boardGameRepository;
        private readonly IGameResultRepository _gameResultRepository;
        private readonly IGamerRepository _gamerRepository;
        private readonly IGameTableRepository _gameTableRepository;

        public GameResultService(IGameResultRepository gameResultRepository, IGamerRepository gamerRepository,
            IGameTableRepository gameTableRepository, IBoardGameRepository boardGameRepository)
        {
            _gameResultRepository = gameResultRepository;
            _gamerRepository = gamerRepository;
            _gameTableRepository = gameTableRepository;
            _boardGameRepository = boardGameRepository;
        }

        public IEnumerable<GameResultDto> GetAllGameResults()
        {
            var gameResultList = _gameResultRepository.GetAll().ToList();
            return MapGameResultListToGameResultDtoList(gameResultList);
        }

        public IEnumerable<GameResult> GetAllGameResultsByTableId(int id)
        {
            return _gameResultRepository.GetAllByTableId(id);
        }

        public IEnumerable<GameResultDto> GetAllByGamerNickname(string nickname)
        {
            var gameResultList = _gameResultRepository.GetAllByGamerNickname(nickname).ToList();
            return MapGameResultListToGameResultDtoList(gameResultList);
        }

        public void AddGameResult(GameResultDto gameResultDto, Gamer gamer)
        {
            var gameResult = MapGameResultDtoToGameResultWithReferences(gameResultDto, gamer);
            _gameResultRepository.Add(gameResult);
        }

        public void AddGameResults(List<GameResultDto> gameResultDtoList, Gamer gamer)
        {
            var gameResults = new List<GameResult>();
            foreach (var gameResultDto in gameResultDtoList)
            {
                var gameResult = MapGameResultDtoToGameResultWithReferences(gameResultDto, gamer);
                gameResult.CreatedGamerId = gamer.Id;
                gameResults.Add(gameResult);
            }

            _gameResultRepository.AddMany(gameResults);
        }

        public void EditGameResult(GameResult gameResult)
        {
            _gameResultRepository.Edit(gameResult);
        }

        public void DeactivateGameResult(int id)
        {
            _gameResultRepository.Deactivate(id);
        }

        public GameResultDto GetGameResult(int id)
        {
            var gameResult = _gameResultRepository.Get(id);
            var gameResultDto = Mapper.Map<GameResultDto>(gameResult);
            gameResultDto.CreatedGamerNickname =
                _gamerRepository.Get(Guid.Parse(gameResultDto.CreatedGamerId))?.Nickname;

            if (gameResultDto.GameTableId.HasValue)
                gameResultDto.GameTableName =
                    _gameTableRepository.Get(gameResultDto.GameTableId.Value)?.Name;

            return gameResultDto;
        }

        private GameResult MapGameResultDtoToGameResultWithReferences(GameResultDto gameResultDto, Gamer gamer)
        {
            GameTable gameTable = null;
            if (gameResultDto.GameTableId.HasValue)
                gameTable = _gameTableRepository.Get(gameResultDto.GameTableId.Value);

            var boardGame = _boardGameRepository.Get(gameResultDto.BoardGameId);

            var gameResult = Mapper.Map<GameResultDto, GameResult>(gameResultDto);
            Mapper.Map(gamer, gameResult);
            Mapper.Map(gameTable, gameResult);
            Mapper.Map(boardGame, gameResult);
            return gameResult;
        }

        private IEnumerable<GameResultDto> MapGameResultListToGameResultDtoList(List<GameResult> gameResultList)
        {
            var gameResultDtoList =
                Mapper.Map<List<GameResult>, List<GameResultDto>>(gameResultList);

            foreach (var gameResultDto in gameResultDtoList)
                gameResultDto.CreatedGamerNickname =
                    _gamerRepository.Get(Guid.Parse(gameResultDto.CreatedGamerId))?.Nickname;
            return gameResultDtoList;
        }
    }
}