﻿using System;
using System.Collections.Generic;

namespace BoardGamesNook.ViewModels.GameTable
{
    public class GameTableViewModel
    {
        public int Id { get; set; }
        public int GamerId { get; set; }
        public string GamerNick { get; set; }
        //TODO: allow multiple games
        public IEnumerable<TableBoardGameViewModel> TableBoardGameList { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public int PlayersNumber { get; set; }
        public bool IsPrivate { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        //public IEnumerable<GameParticipation> GameParticipationInfo { get; set; }
    }
}