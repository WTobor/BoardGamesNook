namespace BoardGamesNook.ViewModels.GameResult
{
    public class GameResultViewModel
    {
        public string Id { get; set; }
        public string CreatedGamerId { get; set; }
        public string CreatedGamerNickname { get; set; }
        public string GamerId { get; set; }
        public string GamerNickname { get; set; }
        public int BoardGameId { get; set; }
        public string BoardGameName { get; set; }
        public float? Points { get; set; }
        public int? Place { get; set; }
        public int PlayersNumber { get; set; }
        public int? GameTableId { get; set; }
        public string GameTableName { get; set; }
    }
}