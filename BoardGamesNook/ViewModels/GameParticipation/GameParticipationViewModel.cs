namespace BoardGamesNook.ViewModels.GameParticipation
{
    public class GameParticipationViewModel
    {
        public int Id { get; set; }
        public string CreatedGamerId { get; set; }
        public int GameTableId { get; set; }
        public Model.GameTable GameTable { get; set; }
        public string GamerId { get; set; }
        public Model.Gamer Gamer { get; set; }
        public bool IsConfirmed { get; set; }
        public int Status { get; set; }
    }
}