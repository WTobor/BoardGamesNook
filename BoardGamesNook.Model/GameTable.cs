using System;
using System.Collections.Generic;

namespace BoardGamesNook.Model
{
    public class GameTable
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public int CreatedGamerId { get; set; }
        public Gamer CreatedGamer { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public int? ModifiedGamerId { get; set; }
        public Gamer ModifiedGamer { get; set; }
        public int PlayersNumber { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsFull { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public bool Active { get; set; }
        public List<BoardGame> BoardGames { get; set; }
        public List<GameParticipation> GameParticipationInfo { get; set; }
    }
}
