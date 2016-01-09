using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MeditWebApp1.Startup))]
namespace MeditWebApp1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
