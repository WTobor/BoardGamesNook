using BoardGamesNook.Validators;
using FluentValidation.Attributes;

namespace BoardGamesNook.ViewModels.Gamer
{
    [Validator(typeof(GamerValidator))]
    public class GamerViewModel
    {
        public string Id { get; set; }
        public string Nickname { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}