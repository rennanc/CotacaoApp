using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CotacaoApp.Startup))]
namespace CotacaoApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
