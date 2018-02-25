namespace BoardGamesNook.Services.Models
{
    public class TableBoardGameDto
    {
        public int BoardGameId { get; set; }
        public int? BGGId { get; set; }
        public string BoardGameName { get; set; }
        public int MinBoardGamePlayers { get; set; }
        public int MaxBoardGamePlayers { get; set; }
        public string ImageUrl { get; set; }
        public int TableId { get; set; }
        public string TableName { get; set; }
        public string GamerId { get; set; }
        public string GamerNickname { get; set; }
    }
}