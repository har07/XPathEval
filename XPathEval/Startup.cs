using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(XPathEval.Startup))]
namespace XPathEval
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
