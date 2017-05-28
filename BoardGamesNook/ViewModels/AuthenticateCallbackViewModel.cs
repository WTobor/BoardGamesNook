using System;
using SimpleAuthentication.Core;

namespace BoardGamesNook.ViewModels
{
    public class AuthenticateCallbackViewModel
    {
        public IAuthenticatedClient AuthenticatedClient { get; set; }
        public Exception Exception { get; set; }
        public string ReturnUrl { get; set; }
    }
}