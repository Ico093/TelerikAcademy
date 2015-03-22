using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WorkingWithData.Startup))]
namespace WorkingWithData
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
