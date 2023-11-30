using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Eportafolio1.Startup))]
namespace Eportafolio1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
