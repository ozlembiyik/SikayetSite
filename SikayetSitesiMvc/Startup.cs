using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SikayetSitesiMvc.Startup))]
namespace SikayetSitesiMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
