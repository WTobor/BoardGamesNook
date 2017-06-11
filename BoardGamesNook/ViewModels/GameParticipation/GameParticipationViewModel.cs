namespace BoardGamesNook.ViewModels.GameParticipation
{
    public class GameParticipationViewModel
    {
        public int Id { get; set; }
        public int CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public int GameTableId { get; set; }
        public Model.GameTable GameTable { get; set; }
        public int GamerId { get; set; }
        public Model.Gamer Gamer { get; set; }
        public bool IsConfirmed { get; set; }
        public int Status { get; set; }
        public bool Active { get; set; }
    }
}