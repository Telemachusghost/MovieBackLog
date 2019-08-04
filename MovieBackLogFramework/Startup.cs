using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieBackLogFramework.Startup))]
namespace MovieBackLogFramework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
