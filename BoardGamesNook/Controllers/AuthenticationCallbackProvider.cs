using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BoardGamesNook.Model;
using BoardGamesNook.Services;
using Newtonsoft.Json;
using SimpleAuthentication.Mvc;

namespace BoardGamesNook.Controllers
{
    public class AuthenticationCallbackProvider : IAuthenticationCallbackProvider
    {
        // Tutaj również wstrzykiaanie zależności przez konstruktor (pomijając fakt, że ten serwis nie jest nigdzie używany).
        private UserService userService = new UserService();

        public ActionResult Process(HttpContextBase context, AuthenticateCallbackData model)
        {
            // Ten cały kod, włącznie z tworzeniem Usera powinien być w osobnej metodzie.
            var email = model.AuthenticatedClient.UserInformation.Email;
            var name = model.AuthenticatedClient.UserInformation.Name;
            // userName nie jest nawet nigdzie używany w tej metodzie
            var userName = model.AuthenticatedClient.UserInformation.UserName;
            var picture = model.AuthenticatedClient.UserInformation.Picture;

            var loggedUser = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                ImageUrl = picture,
                Email = email
            };

            return new RedirectToRouteResult(new RouteValueDictionary
            {
                { "action", "Set" },
                { "controller", "User" },
                { "userJson", JsonConvert.SerializeObject(loggedUser) }
            });
        }

        public ActionResult OnRedirectToAuthenticationProviderError(HttpContextBase context, string errorMessage)
        {
            return new RedirectResult("/", true);
        }
    }
}