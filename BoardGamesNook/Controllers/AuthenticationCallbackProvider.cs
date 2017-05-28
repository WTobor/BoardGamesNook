using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using BoardGamesNook.Model;
using BoardGamesNook.Services;
using BoardGamesNook.ViewModels.User;
using SimpleAuthentication.Mvc;

namespace BoardGamesNook.Controllers
{
    public class AuthenticationCallbackProvider : IAuthenticationCallbackProvider
    {
        private UserService userService = new UserService();

        public ActionResult Process(HttpContextBase context, AuthenticateCallbackData model)
        {
            var email = model.AuthenticatedClient.UserInformation.Email;
            var name = model.AuthenticatedClient.UserInformation.Name;
            var userName = model.AuthenticatedClient.UserInformation.UserName;
            var picture = model.AuthenticatedClient.UserInformation.Picture;

            var loggedUser = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                ImageUrl = picture,
                Email = email
            };

            //userService.SetUser(loggedUser);
            context.Items.Add("User", loggedUser);

            return new RedirectResult("/", true);
        }

        public ActionResult OnRedirectToAuthenticationProviderError(HttpContextBase context, string errorMessage)
        {
            return new RedirectResult("/", true);
        }
    }
}