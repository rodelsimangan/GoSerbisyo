using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoSerbisyo.Startup))]
namespace GoSerbisyo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
