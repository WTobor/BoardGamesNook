using System;
using System.Collections.Generic;

namespace BoardGamesNook.ViewModels.GameTable
{
    public class GameTableViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GamerId { get; set; }
        public string GamerNickname { get; set; }

        //TODO: allow multiple games
        public IEnumerable<TableBoardGameViewModel> TableBoardGameList { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public bool IsPrivate { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        //public IEnumerable<GameParticipation> GameParticipationInfo { get; set; }
    }
}