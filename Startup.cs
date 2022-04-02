using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExoGym.Startup))]
namespace ExoGym
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
