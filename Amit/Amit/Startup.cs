using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Amit.Startup))]
namespace Amit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
