using System.Collections.Generic;
using System.Linq;
using BoardGamesNook.Model;
using BoardGamesNook.ViewModels.GameParticipation;

namespace BoardGamesNook.Mappers
{
    public class GameParticipationMapper
    {
        public static IEnumerable<GameParticipationViewModel> MapToGameParticipationViewModelList(IEnumerable<GameParticipation> gameParticipations)
        {
            return gameParticipations.Select(MapToGameParticipationViewModel).ToList();
        }

        public static GameParticipationViewModel MapToGameParticipationViewModel(GameParticipation gameParticipation)
        {
            return new GameParticipationViewModel()
            {
                Id = gameParticipation.Id,
                GameTableId = gameParticipation.GameTableId,
                GameTable = gameParticipation.GameTable,
                GamerId = gameParticipation.GamerId,
                Gamer = gameParticipation.Gamer,
                CreatedGamerId = gameParticipation.CreatedGamerId,
                IsConfirmed = gameParticipation.IsConfirmed,
                Status = gameParticipation.Status
            };
        }

        public static GameParticipation MapToGameParticipation(GameParticipationViewModel gameParticipationViewModel)
        {
            return new GameParticipation()
            {
                Id = gameParticipationViewModel.Id,
                GameTableId = gameParticipationViewModel.GameTableId,
                GameTable = gameParticipationViewModel.GameTable,
                GamerId = gameParticipationViewModel.GamerId,
                Gamer = gameParticipationViewModel.Gamer,
                CreatedGamerId = gameParticipationViewModel.CreatedGamerId,
                IsConfirmed = gameParticipationViewModel.IsConfirmed,
                Status = gameParticipationViewModel.Status,
                Active = true
            };
        }
    }
}