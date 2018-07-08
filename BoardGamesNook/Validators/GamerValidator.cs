using BoardGamesNook.ViewModels.Gamer;
using FluentValidation;

namespace BoardGamesNook.Validators
{
    public class GamerValidator : AbstractValidator<GamerViewModel>
    {
        public GamerValidator()
        {
            RuleFor(gamer => gamer.Nickname)
                .NotEmpty().WithMessage("Podaj nick!")
                .MinimumLength(3).WithMessage("Nickname musi się składać z minimum 3 znaków!");
            RuleFor(gamer => gamer.Name)
                .NotEmpty().WithMessage("Podaj imię!")
                .MinimumLength(3).WithMessage("Imię musi się składać z minimum 3 znaków!")
                .Matches("^[a-zA-Z\\s]+$").WithMessage("Imię musi się składać z liter!");
            RuleFor(gamer => gamer.Surname)
                .NotEmpty().WithMessage("Podaj nazwisko!")
                .MinimumLength(3).WithMessage("Nazwisko musi się składać z minimum 3 znaków!")
                .Matches("^[a-zA-Z\\s]+$").WithMessage("Nazwisko musi się składać z liter!");
            RuleFor(gamer => gamer.Email)
                .NotEmpty().WithMessage("Podaj adres email!")
                .EmailAddress().WithMessage("Nieprawidłowy adres email!");
            RuleFor(gamer => gamer.City)
                .NotEmpty().WithMessage("Podaj miasto!")
                .MinimumLength(3).WithMessage("Nazwa miasta musi się składać z minimum 3 znaków!")
                .Matches("^[a-zA-Z\\s]+$").WithMessage("Miasto musi się składać z liter!");
        }
    }
}