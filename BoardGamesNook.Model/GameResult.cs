using System;

namespace BoardGamesNook.Model
{
    public class GameResult
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public string CreatedGamerId { get; set; }
        public string GamerId { get; set; }
        public int BoardGameId { get; set; }
        public Gamer Gamer { get; set; }
        public BoardGame BoardGame { get; set; }
        public float? Points { get; set; }
        public int? Place { get; set; }
        public int PlayersNumber { get; set; }
        public int? GameTableId { get; set; }
        public GameTable GameTable { get; set; }
    }
}