using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(xpathfiddle.Startup))]
namespace xpathfiddle
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
