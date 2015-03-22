using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LybrarySystem.Startup))]
namespace LybrarySystem
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
