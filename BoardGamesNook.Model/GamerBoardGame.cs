
using System;

namespace BoardGamesNook.Model
{
    public class GamerBoardGame
    {
        public int Id { get; set; }
        public int GamerId { get; set; }
        public int BoardGameId { get; set; }
        public Gamer Gamer { get; set; }
        public BoardGame BoardGame { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}
