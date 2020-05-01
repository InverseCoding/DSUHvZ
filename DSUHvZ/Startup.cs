using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DSUHvZ.Startup))]
namespace DSUHvZ
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
