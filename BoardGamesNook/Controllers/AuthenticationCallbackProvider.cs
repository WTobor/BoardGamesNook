﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;
using BoardGamesNook.Model;
using BoardGamesNook.Services;
using BoardGamesNook.ViewModels.User;
using Newtonsoft.Json;
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
            //context.Items.Add("User", loggedUser);

            return new RedirectToRouteResult(new RouteValueDictionary
            {
                { "action", "SetUser" },
                { "controller", "User" },
                { "userJson", JsonConvert.SerializeObject(loggedUser) }
            });
            //RedirectResult("/User/SetUser", true);
        }

        public ActionResult OnRedirectToAuthenticationProviderError(HttpContextBase context, string errorMessage)
        {
            return new RedirectResult("/", true);
        }
    }
}