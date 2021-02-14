using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Movieship.Startup))]
namespace Movieship
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
