using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BoardGameNook.Startup))]
namespace BoardGameNook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
