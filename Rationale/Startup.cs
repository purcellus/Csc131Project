using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rationale.Startup))]
namespace Rationale
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
