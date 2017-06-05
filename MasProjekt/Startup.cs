using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MasProjekt.Startup))]
namespace MasProjekt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
