﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BoardGamesNook.Model;
using BoardGamesNook.ViewModels.GamerBoardGame;
using BoardGamesNook.ViewModels.GameTable;

namespace BoardGamesNook.Mappers
{
    public class GameTableMapper
    {
        public static IEnumerable<GameTableViewModel> MapToGameTableViewModelList(IEnumerable<GameTable> gameTableList, int? gamerId = null)
        {
            if (gamerId != null)
            {
                return gameTableList.Where(x => x.CreatedGamerId == gamerId).Select(x => MapToGameTableViewModel(x)).ToList();
            }
            return gameTableList.Select(x => MapToGameTableViewModel(x)).ToList();
        }

        public static GameTableViewModel MapToGameTableViewModel(GameTable gameTable)
        {
            return new GameTableViewModel()
            {
                Id = gameTable.Id,
                IsPrivate = gameTable.IsPrivate,
                City = gameTable.City,
                Street = gameTable.Street,
                PlayersNumber = gameTable.PlayersNumber,
                CreatedDate = gameTable.CreatedDate,
                GamerId = gameTable.CreatedGamer.Id,
                GamerNick = gameTable.CreatedGamer.Nick,
                TableBoardGameList = gameTable.BoardGames == null ? null :  MapToTableBoardGameViewModelList(gameTable.BoardGames, gameTable)
            };
        }

        public static IEnumerable<TableBoardGameViewModel> MapToTableBoardGameViewModelList(IEnumerable<BoardGame> boardGameList, GameTable table)
        {
            return boardGameList.Select(x => MapToTableBoardGameViewModel(x, table)).ToList();
        }

        public static TableBoardGameViewModel MapToTableBoardGameViewModel(BoardGame boardGame, GameTable table)
        {
            return new TableBoardGameViewModel()
            {
                BoardGameId = boardGame.Id,
                BGGId = boardGame.BGGId,
                BoardGameName = boardGame.Name,
                GamerId = table.CreatedGamer.Id,
                GamerNick = table.CreatedGamer.Nick,
                ImageUrl = boardGame.ImageUrl
            };
        }
    }
}