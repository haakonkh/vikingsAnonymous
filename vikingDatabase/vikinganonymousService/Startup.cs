using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(vikinganonymousService.Startup))]

namespace vikinganonymousService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}