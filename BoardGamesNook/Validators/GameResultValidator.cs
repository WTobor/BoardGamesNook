using BoardGamesNook.ViewModels.GameResult;
using FluentValidation;

namespace BoardGamesNook.Validators
{
    public class GameResultValidator : AbstractValidator<GameResultViewModel>
    {
        public GameResultValidator()
        {
            RuleFor(gameResult => gameResult.PlayersNumber)
                .GreaterThanOrEqualTo(gameResult => gameResult.Place.Value)
                .When(gameResult => gameResult.Place.HasValue)
                .WithMessage("Maksymalna liczba graczy musi być większa lub równa zajętemu miejscu!");
        }
    }
}