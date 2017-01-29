using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OmertexBusTicketsSystem.Startup))]
namespace OmertexBusTicketsSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
