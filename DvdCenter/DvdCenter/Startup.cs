using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DvdCenter.Startup))]
namespace DvdCenter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
