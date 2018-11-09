using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PackageMail.Startup))]
namespace PackageMail
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
