using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Decaf.Startup))]
namespace Decaf
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
