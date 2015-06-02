using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(kicsivaros_0602.Startup))]
namespace kicsivaros_0602
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
