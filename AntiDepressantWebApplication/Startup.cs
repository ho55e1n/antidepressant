using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AntiDepressantWebApplication.Startup))]
namespace AntiDepressantWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
