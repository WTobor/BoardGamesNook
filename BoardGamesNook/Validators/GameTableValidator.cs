using BoardGamesNook.ViewModels.GameTable;
using FluentValidation;

namespace BoardGamesNook.Validators
{
    public class GameTableValidator : AbstractValidator<GameTableViewModel>
    {
        public GameTableValidator()
        {
            RuleFor(gameTable => gameTable.City).MinimumLength(3).WithMessage("Miasto musi mieć minimum 3 znaki!");
            RuleFor(gameTable => gameTable.City).Matches("^[a-zA-Z\\s]+$")
                .WithMessage("Miasto musi się składać z liter!");
        }
    }
}