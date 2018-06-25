using BoardGamesNook.ViewModels.BoardGame;
using FluentValidation;

namespace BoardGamesNook.Validators
{
    public class BoardGameValidator : AbstractValidator<BoardGameViewModel>
    {
        public BoardGameValidator()
        {
            RuleFor(boardGame => boardGame.MaxPlayers)
                .GreaterThan(0).WithMessage("Maksymalna liczba graczy musi być dodatnia!");
            RuleFor(boardGame => boardGame)
                .Must(boardGame => boardGame.MaxPlayers > boardGame.MinPlayers)
                .WithMessage("Maksymalna liczba graczy musi być większa od minimalnej liczby graczy!");
            RuleFor(boardGame => boardGame.MaxTime)
                .GreaterThan(0).WithMessage("Maksymalny czas gry musi być dodatni!");
        }
    }
}