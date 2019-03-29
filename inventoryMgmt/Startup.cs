using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(inventoryMgmt.Startup))]
namespace inventoryMgmt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
