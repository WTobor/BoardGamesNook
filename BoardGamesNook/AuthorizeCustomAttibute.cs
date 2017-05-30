using System.Web;
using System.Web.Mvc;

namespace BoardGamesNook
{
    public class AuthorizeCustomAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["user"] != null)
                return true;
            else
                return false;
        }
    }
}