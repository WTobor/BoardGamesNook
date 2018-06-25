using BoardGamesNook.ViewModels.GameResult;
using FluentValidation;

namespace BoardGamesNook.Validators
{
    public class GameResultValidator : AbstractValidator<GameResultViewModel>
    {
        public GameResultValidator()
        {
            RuleFor(boardGame => boardGame)
                .Must(gameResult => gameResult.PlayersNumber >= gameResult.Place)
                .WithMessage("Maksymalna liczba graczy musi być większa lub równa zajętemu miejscu!");
        }
    }
}