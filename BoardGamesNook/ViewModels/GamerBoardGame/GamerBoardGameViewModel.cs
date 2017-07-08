namespace BoardGamesNook.ViewModels.GamerBoardGame
{
    public class GamerBoardGameViewModel
    {
        public int Id { get; set; }
        public string GamerId { get; set; }
        public string GamerNick { get; set; }
        public int BoardGameId { get; set; }
        public int? BGGId { get; set; }
        public string BoardGameName { get; set; }
        public string ImageUrl { get; set; }
    }
}