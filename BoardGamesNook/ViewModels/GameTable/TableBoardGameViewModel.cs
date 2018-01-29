namespace BoardGamesNook.ViewModels.GameTable
{
    public class TableBoardGameViewModel
    {
        public int BoardGameId { get; set; }
        public int? BGGId { get; set; }
        public string BoardGameName { get; set; }
        public string ImageUrl { get; set; }
        public int TableId { get; set; }
        public string TableName { get; set; }
        public string GamerId { get; set; }
        public string GamerNickname { get; set; }
    }
}