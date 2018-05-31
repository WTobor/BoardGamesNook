using System.Web;
using System.Web.Mvc;
using BoardGamesNook.Model;

namespace BoardGamesNook
{
    public class AuthorizeCustomAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["user"] != null)
                return true;
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!(filterContext.HttpContext.Session["gamer"] is Gamer))
            {
                filterContext.HttpContext.Response.ContentType = "application/json";
                filterContext.HttpContext.Response.Write(Errors.GamerNotLoggedIn);
                filterContext.HttpContext.Response.End();
            }
        }
    }
}