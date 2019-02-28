using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRM.UI.Startup))]
namespace CRM.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
