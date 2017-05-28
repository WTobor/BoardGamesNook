using System.Web;
using System.Web.Mvc;
using BoardGamesNook.ViewModels;
using SimpleAuthentication.Mvc;

namespace BoardGamesNook.Controllers
{
    public class AuthenticationCallbackProvider : IAuthenticationCallbackProvider
    {
        public ActionResult Process(HttpContextBase context, AuthenticateCallbackData model)
        {
            var email = model.AuthenticatedClient.UserInformation.Email;
            var name = model.AuthenticatedClient.UserInformation.Name;
            var userName = model.AuthenticatedClient.UserInformation.UserName;
            var picture = model.AuthenticatedClient.UserInformation.Picture;

            return new RedirectResult("/", true);
        }

        public ActionResult OnRedirectToAuthenticationProviderError(HttpContextBase context, string errorMessage)
        {
            return new RedirectResult("/", true);
        }
    }
}