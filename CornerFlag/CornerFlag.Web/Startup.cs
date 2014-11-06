using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CornerFlag.Web.Startup))]
namespace CornerFlag.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
