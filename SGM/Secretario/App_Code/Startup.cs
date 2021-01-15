using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Secretario.Startup))]
namespace Secretario
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
