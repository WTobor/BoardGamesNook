using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BoardGamesNook.Model;
using Newtonsoft.Json;
using SimpleAuthentication.Mvc;

namespace BoardGamesNook.Controllers
{
    public class AuthenticationCallbackProvider : IAuthenticationCallbackProvider
    {
        public ActionResult Process(HttpContextBase context, AuthenticateCallbackData model)
        {
            var loggedUser = CreateNewUser(model);

            return new RedirectToRouteResult(new RouteValueDictionary
            {
                {"action", "Set"},
                {"controller", "User"},
                {"userJson", JsonConvert.SerializeObject(loggedUser)}
            });
        }

        public ActionResult OnRedirectToAuthenticationProviderError(HttpContextBase context, string errorMessage)
        {
            return new RedirectResult("/", true);
        }

        private static User CreateNewUser(AuthenticateCallbackData model)
        {
            var email = model.AuthenticatedClient.UserInformation.Email;
            var name = model.AuthenticatedClient.UserInformation.Name;
            var picture = model.AuthenticatedClient.UserInformation.Picture;

            var loggedUser = new User
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                ImageUrl = picture,
                Email = email
            };
            return loggedUser;
        }
    }
}